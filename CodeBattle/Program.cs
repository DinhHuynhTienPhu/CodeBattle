using System.Linq;
using System.IO;
using System.Threading.Tasks;
MyCalculator myCalculator = new MyCalculator();

myCalculator.Calculate();
class NhanVien
{
    public int endYear;
    public bool male;
    public int startYear;
    public int d, m, y; //birth
    public int point = 0;
    public int numberOfWorkingYear = 0;
}
class MyCalculator
{
    bool checkYear(int year)
    {
        // Nếu số năm chia hết cho 400,
        // đó là 1 năm nhuận
        if (year % 400 == 0)
            return true;

        // Nếu số năm chia hết cho 4 và không chia hết cho 100,
        // đó không là 1 năm nhuận
        if (year % 4 == 0 && year % 100 != 0)
            return true;

        // trường hợp còn lại 
        // không phải năm nhuận
        return false;
    }
    bool isPrime(int n)
    {
        // Corner case
        if (n <= 1)
            return false;

        // Check from 2 to n-1
        for (int i = 2; i < Math.Sqrt( n); i++)
            if (n % i == 0)
                return false;

        return true;
    }
    public List<NhanVien> list = new List<NhanVien>();
    public void Calculate() {
        int sum = 0;
        string[] lines = System.IO.File.ReadAllLines("input.txt");
        List<string> lineList = lines.ToList();
        for (int i = 0; i < lineList.Count; i++)
        {
            var nv= new NhanVien();
            var split  = lineList[i].Split(' ');
            nv.startYear = Int32.Parse(split[1].Split('/')[2]);
            nv.male = split[2] == "nam";
            nv.y = Int32.Parse(split[0].Split('/')[2]);
            nv.m = Int32.Parse(split[0].Split('/')[1]);
            nv.d = Int32.Parse(split[0].Split('/')[0]);
            nv.endYear = nv.male ? nv.d + 60 : nv.d + 55;
            nv.numberOfWorkingYear = nv.endYear - nv.startYear + 1;
            nv.point = 12 * 11 - 4;
            if (nv.m < 4) nv.point *= 3;
            else if(nv.m>=7&&nv.m<=9) nv.point *= 2;
            else if(isPrime( nv.d))  nv.point += (10 + 11 + 10) * 3;
            sum += nv.point * 100;
        }
        Console.WriteLine("sum= " + sum + "k, please check output.txt");
        string text = sum.ToString() + "k";
         File.WriteAllTextAsync("output.txt", text);
    }
    
   
}
