    public class Types{
        public void Method1(){
                
            byte myByte = 255;
            byte mySecondByte = 0;
 

            sbyte mySbyte = 127;
            sbyte mySecondSbyte = -128;
 
            ushort myUshort = 65535;
 
            short myShort = -32768;
 
            // 4 byte (32 bit) 
            int myInt = 2147483647;
            int mySecondInt = -2147483648;
 
            // 8 byte (64 bit) 
            long myLong = -9223372036854775808;
 
 
            // 4 byte (32 bit) 
            float myFloat = 0.751f;
            float mySecondFloat = 0.75f;
 
            // 8 byte (64 bit) floating point number
            double myDouble = 0.751;
            double mySecondDouble = 0.75d;
 
            // 16 byte (128 bit) floating point number, Decimal is better for precise calculations
            decimal myDecimal = 0.751m;
            decimal mySecondDecimal = 0.75m;
 
            //character
            char ch = 'V';
 
            //string datatype
            string myString = "Hello World";
            string myStringWithSymbols = "!@#$@^$%%^&(&%^*__)+%^@##$!@%123589071340698ughedfaoig137";
  
            //boolean
            bool myBool = true;

            // ? can be used to define variable as nullable
            bool ?testBool = null;


            Console.WriteLine($"myByte: {myByte}, mySecondByte: {mySecondByte}, mySbyte: {mySbyte}, mySecondSbyte: {mySecondSbyte}, myUshort: {myUshort}, myShort: {myShort}, myInt: {myInt}, mySecondInt: {mySecondInt}, myLong: {myLong}, myFloat: {myFloat}, mySecondFloat: {mySecondFloat}, myDouble: {myDouble}, mySecondDouble: {mySecondDouble}, myDecimal: {myDecimal}, mySecondDecimal: {mySecondDecimal}, char: {ch}, myString: {myString}, myStringWithSymbols: {myStringWithSymbols}, myBool: {myBool}, testBool: {testBool}");


            //arrays
            int[] arr1 = new int[3];

            int[] arr2 = {1, 2};

            int[] arr3 = new int[3]{1,2,3};

            //Multi-Dimensional, seperated by comma
            int[,] arr2d = new int[3,3];
            
            int[,] arr2dv = new int[,]{
                {1, 2},
                {1, 3}
            };
            arr2dv[0,0] = 5; 

            //Lists

            // Unlike Java, Can also use datatypes as type in list along with classes
            // datatype should be mentioned before and after equals
            // can declare in same line using flower brackets

            List<int> l1 = new List<int>(){1,2};
            List<string> l2 = new List<string>();
            l2.Add("Venkata");
            //Unlike Java, can access the elements same way as arrays
            l2[0] = "C#";


            //Dictionaries are used for key-value pairs, like map in java
            Dictionary<string, int[]> keyValuePairs= new Dictionary<string, int[]>(){
                {"1", new int[]{1,2,3}},
                {"2" , new int[]{1,2}} 
            };
            keyValuePairs["2"][0] = 5;


            //IEnumaberable is faster when we want to loop through every element, like Iterator in Java, we can assign list/arrays to it, Not Indexable
            // First() method can be used to get the first record
            IEnumerable<int> ie = new List<int>(){2,3};

            //Console output
            Console.Write(ch+" "); //no new line
            Console.WriteLine(myString); //new line added at the end
        }
    }