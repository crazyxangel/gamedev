﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Examen
{
	public abstract class levelbytes
	{
		public byte[,] layout{ get; set;}
	}
	public class level1
	{
		public level1()
		{ }
		public byte[,] layout = new byte[17, 32]
		{
            //0: Background, 1: SolidTop, 2: SolidLeft, 3: SolidRight, 4: SolidTopLeft, 5: SolidTopRight, 6: Spike, 7: Acid, 8: RoofSpike
			{ 4,1,8,1,4,1,1,1,1,1,1,1,1,1,8,1   ,1,8,1,1,1,1,1,1,1,1,1,5,1,8,1,5},
			{ 2,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0   ,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,3},
			{ 2,0,2,0,2,0,0,0,3,0,0,0,0,0,2,0   ,0,3,0,0,0,0,0,2,0,0,0,3,0,3,0,3},
			{ 4,1,1,0,2,0,3,0,0,0,3,0,2,0,1,0   ,0,1,0,3,0,2,0,0,0,2,0,3,0,1,1,5},
			{ 2,0,0,0,2,1,0,0,0,0,0,0,0,0,0,0   ,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,3},
			{ 2,1,5,7,2,0,0,0,0,0,0,0,6,0,0,0   ,0,0,0,6,0,0,0,0,0,0,0,3,7,4,1,3},
			{ 2,0,0,1,1,5,0,0,0,0,0,6,4,0,0,0   ,0,0,0,5,6,0,0,0,0,0,4,1,1,0,0,3},
			{ 2,0,0,0,0,0,2,0,2,0,0,4,0,0,0,0   ,0,0,0,0,5,0,0,3,0,3,0,0,0,0,0,3},
			{ 2,2,0,2,0,0,2,0,0,0,6,2,0,0,0,0   ,0,0,0,0,3,6,0,0,0,3,0,0,3,0,3,3},
			{ 5,7,7,7,7,2,2,2,0,0,4,0,0,0,0,0   ,0,0,0,0,0,3,0,0,3,3,3,7,7,7,7,4},
			{ 4,1,8,1,1,0,2,0,0,6,2,0,0,0,0,0   ,0,0,0,0,0,3,6,0,0,3,0,1,1,8,1,5},
			{ 2,0,0,0,0,0,2,0,1,4,0,0,0,1,6,0   ,0,6,1,0,0,0,5,1,0,3,0,0,0,0,0,3},
			{ 2,6,8,1,1,1,0,0,0,2,0,0,2,0,1,0   ,0,1,0,3,0,0,3,0,0,0,1,1,1,8,6,3},
			{ 2,1,0,0,0,0,0,0,1,2,0,0,0,2,0,0   ,0,0,3,0,0,0,3,1,0,0,0,0,0,0,1,3},
			{ 2,0,0,6,0,6,2,6,0,0,0,0,0,0,5,6   ,6,4,0,0,0,0,0,0,6,3,6,0,6,0,0,3},
			{ 2,1,1,1,1,1,0,1,0,0,0,0,0,0,0,1   ,1,0,0,0,0,0,0,0,1,0,1,1,1,1,1,3},
			{ 5,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7   ,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,4},
		};
	}
	public class level2
	{
		public level2()
		{ }
		public byte[,] layout = new byte[17, 32]
		{
            //0: Background, 1: SolidTop, 2: SolidLeft, 3: SolidRight, 4: SolidTopLeft, 5: SolidTopRight, 6: Spike, 7: Acid, 8: RoofSpike
            { 4,1,1,1,1,1,5,1,4,1,1,1,1,1,1,1   ,1,1,1,1,1,1,1,5,1,4,1,1,1,1,1,5},
			{ 2,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0   ,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,3},
			{ 2,0,8,0,0,6,0,0,0,3,0,0,0,0,0,1   ,1,0,0,0,0,0,2,0,0,0,6,0,0,8,0,3},
			{ 2,0,0,0,1,1,5,0,0,3,0,0,2,3,0,0   ,0,0,2,3,0,0,2,0,0,4,1,1,0,0,0,3},
			{ 2,2,0,0,0,0,3,0,0,3,0,0,6,0,0,0   ,0,0,0,6,0,0,2,0,0,2,0,0,0,0,3,3},
			{ 2,0,0,0,0,0,0,5,6,3,0,0,5,7,4,0   ,0,5,7,4,0,0,2,6,4,0,0,0,0,0,0,3},
			{ 2,6,2,3,6,0,1,1,5,0,8,0,0,1,0,3   ,2,0,1,0,0,8,0,4,1,1,0,6,2,3,6,3},
			{ 4,5,7,7,4,0,0,0,3,0,0,5,0,0,0,0   ,0,0,0,0,4,0,0,2,0,0,0,5,7,7,4,5},
			{ 4,8,8,1,5,7,2,0,0,8,2,3,0,0,1,0   ,0,1,0,0,2,3,8,0,0,3,7,4,1,8,8,5},
			{ 2,0,0,0,0,1,5,7,2,0,2,0,5,0,0,2   ,3,0,0,4,0,3,0,3,7,4,1,0,0,0,0,3},
			{ 2,1,5,6,0,0,0,5,0,0,2,0,0,1,0,0   ,0,0,1,0,0,3,0,0,4,0,0,0,6,4,1,3},
			{ 2,0,0,1,5,6,0,3,0,8,5,6,0,6,0,0   ,0,0,6,0,6,4,8,0,2,0,6,4,1,0,0,3},
			{ 2,5,0,0,0,5,0,6,0,0,0,5,0,8,1,0   ,0,1,8,0,4,0,0,0,6,0,4,0,0,0,4,3},
			{ 7,7,7,4,0,3,0,1,8,1,0,3,0,0,0,0   ,0,0,0,0,2,0,1,8,1,0,2,0,5,7,7,7},
			{ 4,1,1,0,0,4,0,0,0,0,3,3,0,0,0,3   ,2,0,0,0,2,2,0,0,0,0,5,0,0,1,1,5},
			{ 2,0,0,0,6,2,0,0,1,0,0,3,0,3,0,0   ,0,0,2,0,2,0,0,1,0,0,3,6,0,0,0,3},
			{ 1,5,7,4,1,1,5,7,7,7,4,1,5,7,7,7   ,7,7,7,4,1,5,7,7,7,4,1,1,5,7,4,1},
		};
	}
}
