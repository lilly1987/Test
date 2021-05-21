using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Mgr mgr = new Mgr();

            Sub0 sub0 = new Sub0();
            Sub1 sub1 = new Sub1();
            Sub2 sub2 = new Sub2();            
            Sub3 sub3 = new Sub3("Sub_3");

            mgr.OnGui();

            Mgr.GoPage(1);
            mgr.OnGui();

            Mgr.GoPage(2);
            mgr.OnGui();
            
            Mgr.GoPage(3);
            mgr.OnGui();
            
            Mgr.GoPage(4);
            mgr.OnGui();

            Console.ReadKey();
        }
    }

    class Mgr
    {
        public string name = "Mgr";

        private static Dictionary<int, Action> actions = new Dictionary<int, Action>();

        public static int pageCount = 0; // 퐁 페이지 수
        public static int pageNow = 0; // 현제 페이지
        public int pageNum = 0; // 해당 클래스 페이지 번호

        public Mgr() : base()
        {
            Seting();
        }

        public Mgr(string name) : base()
        {
            this.name = name;
            Seting();
        }

        public static void GoPage(int p)
        {
            pageNow = (p + pageCount) % pageCount;
        }

        private void Seting()
        {
            actions.Add(pageNum = pageCount++, SetBody);
        }

        public void OnGui()
        {
            GuiFunc(pageNow);
        }

        private void GuiFunc(int windowId)
        {
            actions[windowId]();
        }

        public virtual void SetBody()
        {
            Console.WriteLine("Mgr.SetBody {0} {1} {2} {3}", name, pageNum, pageNow, pageCount);
        }
    }

    class Sub0 : Mgr
    { 
        public override void SetBody()
        {
            //base.SetBody();
            Console.WriteLine("sub0.SetBody {0} {1} {2} {3}", name, pageNum, pageNow, pageCount);
        }
    }
    
    class Sub1 : Mgr
    {
        public Sub1()
        {
            name = "Sub1";
        }

        public override void SetBody()
        {
            //base.SetBody();
            Console.WriteLine("sub1.SetBody {0} {1} {2} {3}", name, pageNum, pageNow, pageCount);
        }
    }

    class Sub2 : Mgr
    {
        public Sub2():base("Sub2")
        {

        }

        public override void SetBody()
        {
            //base.SetBody();
            Console.WriteLine("sub2.SetBody {0} {1} {2} {3}", name, pageNum, pageNow, pageCount);
        }
    }

    class Sub3 : Mgr
    {
        public Sub3( string name):base(name)
        {

        }

        public override void SetBody()
        {
            //base.SetBody();
            Console.WriteLine("sub3.SetBody {0} {1} {2} {3}", name, pageNum, pageNow, pageCount);
        }
    }
}
