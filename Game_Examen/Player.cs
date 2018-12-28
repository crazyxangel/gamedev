using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_Examen
{
    public class Player
    {

        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public TimeSpan Duration { get; set; }
        public bool alive { get; set; }

        private bool _cLeft;
        private bool _cRight;
        private bool _cDown;
        private bool _cUp;
        private bool _left = false;
        private bool _right = true;
        private bool _jump = false;
        private bool _lastjump = false;

        public int _position_left = 400;
        public int _positionalt = 900;

        private int _acceleration;
        private int _accelerationjump;
        private int _deadframes;

        private int jumpheight = 15;
        private int speed = 6;

        private Rectangle _showRectangle;

        public Rectangle playerRectangle { get; set; }

        private Rectangle __collision_left;
        private Rectangle __collision_right;
        private Rectangle __collisionup;
        private Rectangle __collisiondown;

        private Rectangle _idleframeL;
        private Rectangle _idleframeR;

        private Animation _animation_right;
        private Animation _animation_left;
        private Animation _animationjumpL;
        private Animation _animationjumpR;
        private Animation _animationfall;
        private Animation _animationdead;

        private Controls _controls;
        private List<Rectangle> _collision = new List<Rectangle>();
        private List<Rectangle> _collisionLethal = new List<Rectangle>();
        /// <summary>
        /// Hierin worden de animaties aangemaakt
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="player"></param>
        /// <param name="_collisionList"></param>
        /// <param name="lethalList"></param>
        public Player(Texture2D texture, int player, List<Rectangle> _collisionList, List<Rectangle> lethalList)
        {
            _collision = _collisionList;
            _collision.ToArray();
            _collisionLethal = lethalList;
            _collisionLethal.ToArray();
            alive = true;
            _accelerationjump = jumpheight;
            _acceleration = 1;

            if (player == 1)
            {
                _position_left = 0;
                _controls = new ControlP1();
            }
            if (player == 2)
            {
                _position_left = 1860;
                _controls = new ControlP2();
                _right = false;
                _left = true;
            }
            #region Animation _left
            _animation_left = new Animation();
            _animation_left.AddFrame(new Rectangle(0, 120, 60, 60));
            _animation_left.AddFrame(new Rectangle(60, 120, 60, 60));
            _animation_left.AddFrame(new Rectangle(120, 120, 60, 60));
            _animation_left.AddFrame(new Rectangle(180, 120, 60, 60));
            _animation_left.AddFrame(new Rectangle(240, 120, 60, 60));
            _animation_left.AddFrame(new Rectangle(300, 120, 60, 60));
            _animation_left.AddFrame(new Rectangle(360, 120, 60, 60));
            _animation_left.AddFrame(new Rectangle(420, 120, 60, 60));
            Texture = texture;
            _animation_left.MovesaSecond = 16;
            #endregion

            #region Animation _right
            _animation_right = new Animation();
            _animation_right.AddFrame(new Rectangle(0, 60, 60, 60));
            _animation_right.AddFrame(new Rectangle(60, 60, 60, 60));
            _animation_right.AddFrame(new Rectangle(120, 60, 60, 60));
            _animation_right.AddFrame(new Rectangle(180, 60, 60, 60));
            _animation_right.AddFrame(new Rectangle(240, 60, 60, 60));
            _animation_right.AddFrame(new Rectangle(300, 60, 60, 60));
            _animation_right.AddFrame(new Rectangle(360, 60, 60, 60));
            _animation_right.AddFrame(new Rectangle(420, 60, 60, 60));
            Texture = texture;
            _animation_right.MovesaSecond = 16;
            #endregion

            #region Animation _jump R
            _animationjumpR = new Animation();
            _animationjumpR.AddFrame(new Rectangle(0, 0, 60, 60));
            _animationjumpR.AddFrame(new Rectangle(60, 0, 60, 60));
            _animationjumpR.AddFrame(new Rectangle(120, 0, 60, 60));
            _animationjumpR.AddFrame(new Rectangle(180, 0, 60, 60));
            _animationjumpR.AddFrame(new Rectangle(240, 0, 60, 60));
            _animationjumpR.AddFrame(new Rectangle(300, 0, 60, 60));
            _animationjumpR.AddFrame(new Rectangle(360, 0, 60, 60));
            _animationjumpR.AddFrame(new Rectangle(420, 0, 60, 60));
            Texture = texture;
            _animationjumpR.MovesaSecond = 4;
            #endregion

            #region Animation _jump L
            _animationjumpL = new Animation();
            _animationjumpL.AddFrame(new Rectangle(0, 180, 60, 60));
            _animationjumpL.AddFrame(new Rectangle(60, 180, 60, 60));
            _animationjumpL.AddFrame(new Rectangle(120, 180, 60, 60));
            _animationjumpL.AddFrame(new Rectangle(180, 180, 60, 60));
            _animationjumpL.AddFrame(new Rectangle(240, 180, 60, 60));
            _animationjumpL.AddFrame(new Rectangle(300, 180, 60, 60));
            _animationjumpL.AddFrame(new Rectangle(360, 180, 60, 60));
            _animationjumpL.AddFrame(new Rectangle(420, 180, 60, 60));
            Texture = texture;
            _animationjumpL.MovesaSecond = 4;
            #endregion

            #region Animation fall
            _animationfall = new Animation();
            _animationfall.AddFrame(new Rectangle(240, 0, 60, 60));
            _animationfall.AddFrame(new Rectangle(0, 0, 60, 60));
            _animationfall.AddFrame(new Rectangle(240, 0, 60, 60));
            _animationfall.AddFrame(new Rectangle(0, 0, 60, 60));
            Texture = texture;
            _animationfall.MovesaSecond = 4;
            #endregion

            #region Animation dead
            _animationdead = new Animation();
            _animationdead.AddFrame(new Rectangle(0, 300, 60, 60));
            _animationdead.AddFrame(new Rectangle(60, 300, 60, 60));
            _animationdead.AddFrame(new Rectangle(120, 300, 60, 60));
            _animationdead.AddFrame(new Rectangle(180, 300, 60, 60));
            _animationdead.AddFrame(new Rectangle(240, 300, 60, 60));
            _animationdead.AddFrame(new Rectangle(300, 300, 60, 60));
            _animationdead.AddFrame(new Rectangle(360, 300, 60, 60));
            Texture = texture;
            _animationdead.MovesaSecond = 50;
            #endregion

            _idleframeL = new Rectangle(60, 240, 60, 60);
            _idleframeR = new Rectangle(0, 240, 60, 60);
            _showRectangle = new Rectangle(0, 0, 60, 60);
        }

        public virtual void Update(GameTime gameTime)
        {
            movement(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_left)
                _showRectangle = _idleframeL;

            if (_right)
                _showRectangle = _idleframeR;

            if (_controls.left)
                _showRectangle = _animation_left.CurrentFrame.SourceRectangle;

            if (_controls.right)
                _showRectangle = _animation_right.CurrentFrame.SourceRectangle;

            if (_controls.up && _left && _jump)
                _showRectangle = _animationjumpL.CurrentFrame.SourceRectangle;

            if (_controls.up && _right && _jump)
                _showRectangle = _animationjumpR.CurrentFrame.SourceRectangle;

            if (!_collisiondown() && !_jump)
                _showRectangle = _animationfall.CurrentFrame.SourceRectangle;

            if (!amIalive())
                _showRectangle = _animationdead.CurrentFrame.SourceRectangle;

            spriteBatch.Draw(Texture, new Vector2(_position_left, _positionalt), _showRectangle, Color.AliceBlue);
        }

        #region Collision
        /// <summary>
        /// Here we'll check if the	_left side of the robot makes _collision with anything
        /// </summary>
        /// <returns></returns>
        public bool _collision_left()
        {
            _cLeft = false;
            __collision_left = new Rectangle(_position_left + 10, _positionalt+5, 10, 50);
            foreach (Rectangle item in _collision)
            {
                if (item.Intersects(__collision_left))
                    _cLeft = true;
            }
            return _cLeft;
        }
        /// <summary>
        /// Here we'll check if the _right side of the robot makes _collision with anything
        /// </summary>
        /// <returns></returns>
        public bool _collision_right()
        {
            _cRight = false;
            __collision_right = new Rectangle(_position_left + 40, _positionalt+5, 10, 50);
            foreach (Rectangle item in _collision)
            {
                if (item.Intersects(__collision_right))
                    _cRight = true;
            }
            return _cRight;

        }
        /// <summary>
        /// Here we'll check if the top of the robot makes _collision with anything
        /// </summary>
        /// <returns></returns>
        public bool _collisionup()
        {
            _cUp = false;
            __collisionup = new Rectangle(_position_left + 15, _positionalt - 10, 30, 10);
            foreach (Rectangle item in _collision)
            {
                if (item.Intersects(__collisionup))
                    _cUp = true;
            }
            return _cUp;
        }
        /// <summary>
        /// Here we'll check if the bottom of the robot makes _collision with anything
        /// </summary>
        /// <returns></returns>
        public bool _collisiondown()
        {
            _cDown = false;
            __collisiondown = new Rectangle(_position_left + 15, _positionalt + 58, 30, 5);
            foreach (Rectangle item in _collision)
            {
                if (item.Intersects(__collisiondown))
                {
                    _cDown = true;
                    _positionalt = item.Y - 56;
                }
            }
            return _cDown;
        }
        /// <summary>
        /// Here we'll check if the robot makes _collision with a deadly object
        /// </summary>
        /// <returns></returns>

        public bool amIalive()
        {
            playerRectangle = new Rectangle(_position_left + 20, _positionalt+20, 20, 40);
            foreach (Rectangle item in _collisionLethal)
            {
                if (item.Intersects(playerRectangle))
                    alive = false;
            }
            return alive;
        }

        #endregion

        public void movement(GameTime gameTime)

        {

            if (amIalive())
            {
                _controls.Update();
				if (_collisionup())
					_accelerationjump = 0;
                if (!_collisiondown() && !_jump)
                {
                    _positionalt += 1 * _acceleration;
                    _animationfall.Update(gameTime);
                    if (_acceleration < 15)
                        _acceleration += 1;
                }

                if (_collisiondown())
                    _acceleration = 1;

                if (_accelerationjump == 0)
                {
                    _accelerationjump = jumpheight;
                    _jump = false;
                    _lastjump = true;
                }

                if (_controls.left)
                {
                    _left = true;
                    _right = false;
                    if (!_collision_left())
                        _position_left -= speed;

                    _animation_left.Update(gameTime);
                }

                if (_controls.right)
                {
                    _left = false;
                    _right = true;

                    if (!_collision_right())
                        _position_left += speed;

                    _animation_right.Update(gameTime);
                }
                if (_controls.up && !_jump && !_collisionup() && _collisiondown() && !_lastjump)
                    _jump = true;

                if (!_controls.up && _lastjump)
                    _lastjump = false;

                if (_left)
                    _animationjumpL.Update(gameTime);

                if (_right)
                    _animationjumpR.Update(gameTime);

                if (_jump & _left && !_lastjump)
                {
                    _animationjumpL.Update(gameTime);
                    if (!_collisionup())
                        _positionalt -= 1 * _accelerationjump;
                    if (_accelerationjump > 0)
                        _accelerationjump -= 1;
                }
                if (_jump & _right && !_lastjump)
                {
                    _animationjumpR.Update(gameTime);
                    if (!_collisionup())
                        _positionalt -= 1 * _accelerationjump;
                    if (_accelerationjump > 0)
                        _accelerationjump -= 1;
                }
            }
            if (!amIalive())
            {
                if (_deadframes < 12)
                {
                    _animationdead.Update(gameTime);
                    _deadframes++;
                }

                if (!_collisiondown())
                {
                    _positionalt += 1 * _acceleration;
                    if (_acceleration < 15)
                        _acceleration += 1;
                }
            }
            
        }
        public void deadframesdone(GameTime gameTime)
        {

            if (!amIalive())
            {
                if (_deadframes < 12)
                {
                    _animationdead.Update(gameTime);
                    _deadframes++;
                }
            }
        }
    }
}
