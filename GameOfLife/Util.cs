using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
   public static class Util
    {
       public static void CheckNull(object param1)
       {
           if (param1 == null) throw new  ArgumentNullException();
       }


       public static void CheckNull(object param1,object param2)
       {
           CheckNull(param1);
           CheckNull(param2);

       }

       public static void CheckNull(object param1, object param2,object param3)
       {
           CheckNull(param1);
           CheckNull(param2);
           CheckNull(param3);
           
       }

       public static void CheckNull(object param1, object param2, object param3,object param4)
       {
           CheckNull(param1);
           CheckNull(param2);
           CheckNull(param3);
           CheckNull(param4);
       }


   
   }
}
