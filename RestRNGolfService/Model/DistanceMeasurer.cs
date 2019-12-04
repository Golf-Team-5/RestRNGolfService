using System;

namespace RestRNGolfService.Model
{
    public static class DistanceMeasurer
    {

        public static int CalculateDistance(SwingData swingData)
        {

            try
            {
                if (swingData.SwingSpeed != null && swingData.SwingSpeed > 0)
                {
                    int swingDistance = Convert.ToInt32(swingData.SwingSpeed * 3);
                    return swingDistance;
                }
                throw new ArgumentException();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            return 0;



        }


        //Idé til random scenario udvælger
        //public static int CalculateDistance2(SwingData swingData)
        //{
        //    int number = 5;
        //random number generator that generates number

        //    if (number == 9 || number == 10 )
        //    {
        //        //Scenario 1
        //        int swingDistance = 400;
        //        return swingDistance;

        //    }
        //    else if (number == 11 || number == 12)
        //    {
        //        //Scenario 2
        //        int swingDistance = -800;
        //        return swingDistance;
        //    }
        //    else 
        //    {
        //        int swingDistance = Convert.ToInt32(swingData.SwingSpeed * 30);
        //        return swingDistance;
        //    }

        //}


    }
}
