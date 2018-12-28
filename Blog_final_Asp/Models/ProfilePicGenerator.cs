using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public static class ProfilePicGenerator
    {
        public static string GenerateProfilePic()
        {
            Random rand = new Random();
            switch (rand.Next(1, 17))
		{
			case 1:
				    return "Images/profile_pics/defaults/head_alizarin.png";
			case 2:         
                    return "Images/profile_pics/defaults/head_amethyst.png";
			case 3:         
                    return "Images/profile_pics/defaults/head_belize_hole.png";
			case 4:         
                    return "Images/profile_pics/defaults/head_carrot.png";
			case 5:         
                    return "Images/profile_pics/defaults/head_deep_blue.png";
			case 6:         
                    return "Images/profile_pics/defaults/head_emerald.png";
			case 7:         
                    return "Images/profile_pics/defaults/head_green_sea.png";
			case 8:         
                    return "Images/profile_pics/defaults/head_nephritis.png";
			case 9:         
                    return "Images/profile_pics/defaults/head_pete_river.png";
			case 10:        
                    return "Images/profile_pics/defaults/head_pomegranate.png";
			case 11:        
                    return "Images/profile_pics/defaults/head_pumpkin.png";
			case 12:        
                    return "Images/profile_pics/defaults/head_red.png";
			case 13:        
                    return "Images/profile_pics/defaults/head_sun_flower.png";
			case 14:        
                    return "Images/profile_pics/defaults/head_turqoise.png";
			case 15:        
                    return "Images/profile_pics/defaults/head_wet_asphalt.png";
			case 16:        
                    return "Images/profile_pics/defaults/head_wisteria.png";
            default:
                    return "Error";
            }
        }
    }
}