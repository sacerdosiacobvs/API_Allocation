using System;

namespace API_Allocator
{
    public class Allocator
    {
        public string name { get; set; }
        public int large { get; set; }
        public int xlarge { get; set; }

        public int x2large { get; set; }

        public int x4large { get; set; }

        public int x8large { get; set; }

        public int x10large { get; set; }

        public int costo { get; set; }

        public string Calcular(string region, int units, int hours)
        {
            int i_10 = 0, i_8 = 0, i_4 = 0, i_2 = 0, i_x = 0, i_l = 0;



            Asignar(region);

            int costo = 0;

            do
            {
                if ((units >= 320 && region != "China") && ((x8large * hours*units) > (x10large * hours * units)))       //10x 
                {
                    units = units - 320;

                    costo = costo + (x10large*hours);
                    i_10++;
                }
                else
                {
                    if ((units >= 160))       //8x
                    {
                        units = units - 160;

                        costo = costo + (x8large * hours);
                        i_8++;
                    }
                    else
                    {
                        if((units >= 80))     //x4
                        {
                            units = units - 80;

                            costo = costo + (x4large * hours);
                            i_4++;
                        }
                        else
                        {
                            if ((units >= 40 && region != "China"))     //x2
                            {
                                units = units - 40;

                                costo = costo + (x2large * hours);
                                i_2++;
                            }
                            else
                            {
                                if ((units >= 20 && region!="India"))     //x
                                {
                                    units = units - 20;

                                    costo = costo + (xlarge * hours);
                                    i_x++;
                                }
                                else
                                {
                                    if (units >= 10)     //large
                                    {
                                        units = units - 10;

                                        costo = costo + (large * hours);
                                        i_l++;
                                    }
                                }
                            }
                        }
                    }
                }

            } while (units >= 10);



            string cantidad_maquinas = Total_Maquinas(i_10 , i_8 , i_4 , i_2 , i_x , i_l );

            return "\nRegion: "+region+"\nTotal cost: $"+costo+"\n"+cantidad_maquinas;
        }

        public void Asignar(string region)          
        {
            switch (region)
            {
                case "New York":
                    large = 120;
                    xlarge = 230;
                    x2large = 450;
                    x4large = 774;
                    x8large = 1400;
                    x10large = 2820;            //valores siempre mas del doble de 8x nunca va a entrar
                    break;

                case "India":
                    large = 140;
                    xlarge = 0;
                    x2large = 413;
                    x4large = 890;
                    x8large = 1300;
                    x10large = 2970;
                    break;

                case "China":
                    large = 110;
                    xlarge = 200;
                    x2large = 0;
                    x4large = 670;
                    x8large = 1180;
                    x10large = 0;
                    break;

                default:
                    break;
            }
        }

        public string Total_Maquinas(int i_10, int i_8 , int i_4 , int i_2 , int i_x , int i_l)
        {
            string res = "Machines:\n";

            if (i_10 != 0)
            {
                res = res+"10XLarge = "+(i_10)+"\n";
            }
            if (i_8 != 0)
            {
                res = res + "8XLarge = " + (i_8) + "\n";
            }
            if (i_4 != 0)
            {
                res = res + "4XLarge = " + (i_4) + "\n";
            }
            if (i_2 != 0)
            {
                res = res + "2XLarge = " + (i_2) + "\n";
            }
            if (i_x != 0)
            {
                res = res + "XLarge = " + (i_x) + "\n";
            }
            if (i_l != 0)
            {
                res = res + "Large = " + (i_l) + "\n";
            }

            return res;
        }
    }
}
