using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct5th
{
    class CCalendar
    {
        DateTime myDate;
        int sexagenaryYear;                 //甲子中的年份            
        int celestialStem;    //年份天干
        int terrestrialBranch;//年份地支
        int cnMonth;                //月份
        int cnLeapMonth;            //闰月
        int cnDay;                  //日子
                                    //年份用，天干与地支数组
        string[] arrCelestialStem = { "", "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
        string[] arrTerrestriaBranch = { "", "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "酉", "戌", "亥" };
        //月份名称
        string[] arrMonthName = { "", "正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "冬月", "腊月" };
        //日子
        string[] arrDayName = { "", "初一", "初二", "初三", "初四", "初五", "初六", "初七", "初八", "初九", "初十", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十", "廿一", "廿二", "廿三", "廿四", "廿五", "廿六", "廿七", "廿八", "廿九", "三十" };
        public  CCalendar(DateTime date)
        {
            //农历日历
            myDate = date;
            ChineseLunisolarCalendar cnCalendar = new ChineseLunisolarCalendar();
            //计算农历年份
            sexagenaryYear = cnCalendar.GetSexagenaryYear(myDate);
            //计算农历天干
            celestialStem = cnCalendar.GetCelestialStem(sexagenaryYear);
            //计算农历地支
            terrestrialBranch = cnCalendar.GetTerrestrialBranch(sexagenaryYear);
            //计算月份
            cnMonth = cnCalendar.GetMonth(myDate);
            //计算日子
            cnDay = cnCalendar.GetDayOfMonth(myDate);
            //闰月
            cnLeapMonth = 0;
            if (myDate.Month < 3 && cnMonth > 9)
            {
                cnLeapMonth = cnCalendar.GetLeapMonth(myDate.Year - 1);
            }
            else
            {
                cnLeapMonth = cnCalendar.GetLeapMonth(myDate.Year);
            }
        }//初始化
        public string GetYearName()
        {
            return arrCelestialStem[celestialStem] + arrTerrestriaBranch[terrestrialBranch] + "年";
        }//获取年份，天干+地支
        public void showCnYear()
        {
            Console.Write(arrCelestialStem[celestialStem] + arrTerrestriaBranch[terrestrialBranch] + "年");
        } //显示年份，天干+地支
        public string GetMonthName()
        {
            if (cnLeapMonth == 0 || cnMonth < cnLeapMonth)
            {
                return arrMonthName[cnMonth];
            }
            else if (cnMonth == cnLeapMonth)
            {
                return "闰" + arrMonthName[cnMonth - 1];
            }
            else
            {
                return arrMonthName[cnMonth - 1];
            }
        }//获取月份，注意闰月情况
        public void showCnMonth()
        {
            if (cnLeapMonth == 0 || cnMonth < cnLeapMonth)
            {
                Console.Write(arrMonthName[cnMonth]);
            }
            else if (cnMonth == cnLeapMonth)
            {
                Console.Write("闰" + arrMonthName[cnMonth - 1]);
            }
            else
            {
                Console.Write(arrMonthName[cnMonth - 1]);
            }
        }//显示月份，注意闰月情况
        public string GetDayName()
        {
            return arrDayName[cnDay];
        }//获取日子
        public void showDay()
        {
            Console.Write(arrDayName[cnDay]);
        }//显示日子


    }//农历信息(表驱动法)以空间换取时间
}
