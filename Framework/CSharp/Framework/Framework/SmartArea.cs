﻿/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 区域
    /// </summary>
    public class SmartArea
    {
        /// <summary>
        /// 所有
        /// </summary>
        public static readonly List<SmartArea> All = new List<SmartArea>();

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static SmartArea()
        {
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "安庆", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "anqing", PostCode = "246000", PhoneCode = "0556" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "蚌埠", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "bangbu", PostCode = "233000", PhoneCode = "0552" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "亳州", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "haozhou", PostCode = "236000", PhoneCode = "0558" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "巢湖", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "chaohu", PostCode = "238000", PhoneCode = "0565" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "池州", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "chizhou", PostCode = "247100", PhoneCode = "0566" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "滁州", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "chuzhou", PostCode = "239000", PhoneCode = "0550" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "阜阳", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "fuyang", PostCode = "236000", PhoneCode = "0558" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "合肥", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "hefei", PostCode = "230000", PhoneCode = "0551" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "淮北", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "huaibei", PostCode = "235000", PhoneCode = "0561" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "淮南", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "huainan", PostCode = "232000", PhoneCode = "0554" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "黄山", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "huangshan", PostCode = "242700", PhoneCode = "0559" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "六安", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "liuan", PostCode = "237000", PhoneCode = "0564" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "马鞍山", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "maanshan", PostCode = "243000", PhoneCode = "0555" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "宿州", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "suzhou", PostCode = "234000", PhoneCode = "0557" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "铜陵", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "tongling", PostCode = "244000", PhoneCode = "0562" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "芜湖", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "wuhu", PostCode = "241000", PhoneCode = "0553" });
            All.Add(new SmartArea() { Country = "中国", Province = "安徽", City = "宣城", CountryPinyin = "zhongguo", ProvincePinyin = "anhui", CityPinyin = "xuancheng", PostCode = "242000", PhoneCode = "0563" });
            All.Add(new SmartArea() { Country = "中国", Province = "北京", City = "北京", CountryPinyin = "zhongguo", ProvincePinyin = "beijing", CityPinyin = "beijing", PostCode = "100000", PhoneCode = "010" });
            All.Add(new SmartArea() { Country = "中国", Province = "福建", City = "福州", CountryPinyin = "zhongguo", ProvincePinyin = "fujian", CityPinyin = "fuzhou", PostCode = "350000", PhoneCode = "0591" });
            All.Add(new SmartArea() { Country = "中国", Province = "福建", City = "龙岩", CountryPinyin = "zhongguo", ProvincePinyin = "fujian", CityPinyin = "longyan", PostCode = "364000", PhoneCode = "0597" });
            All.Add(new SmartArea() { Country = "中国", Province = "福建", City = "南平", CountryPinyin = "zhongguo", ProvincePinyin = "fujian", CityPinyin = "naping", PostCode = "353000", PhoneCode = "0599" });
            All.Add(new SmartArea() { Country = "中国", Province = "福建", City = "宁德", CountryPinyin = "zhongguo", ProvincePinyin = "fujian", CityPinyin = "ningde", PostCode = "352000", PhoneCode = "0593" });
            All.Add(new SmartArea() { Country = "中国", Province = "福建", City = "莆田", CountryPinyin = "zhongguo", ProvincePinyin = "fujian", CityPinyin = "putian", PostCode = "351100", PhoneCode = "0594" });
            All.Add(new SmartArea() { Country = "中国", Province = "福建", City = "泉州", CountryPinyin = "zhongguo", ProvincePinyin = "fujian", CityPinyin = "quanzhou", PostCode = "362000", PhoneCode = "0595" });
            All.Add(new SmartArea() { Country = "中国", Province = "福建", City = "三明", CountryPinyin = "zhongguo", ProvincePinyin = "fujian", CityPinyin = "sanming", PostCode = "365000", PhoneCode = "0598" });
            All.Add(new SmartArea() { Country = "中国", Province = "福建", City = "厦门", CountryPinyin = "zhongguo", ProvincePinyin = "fujian", CityPinyin = "xiamen", PostCode = "361000", PhoneCode = "0592" });
            All.Add(new SmartArea() { Country = "中国", Province = "福建", City = "漳州", CountryPinyin = "zhongguo", ProvincePinyin = "fujian", CityPinyin = "zhangzhou", PostCode = "363000", PhoneCode = "0596" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "白银", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "baiyin", PostCode = "730900", PhoneCode = "0943" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "定西", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "dingxi", PostCode = "743000", PhoneCode = "0932" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "甘南", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "ganna", PostCode = "747000", PhoneCode = "0941" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "嘉峪关", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "jiayuguan", PostCode = "735100", PhoneCode = "0937" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "金昌", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "jinchang", PostCode = "737100", PhoneCode = "0935" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "酒泉", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "jiuquan", PostCode = "735000", PhoneCode = "0937" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "兰州", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "lanzhou", PostCode = "730000", PhoneCode = "0931" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "临夏", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "linxia", PostCode = "731100", PhoneCode = "0930" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "陇南", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "longnan", PostCode = "742500", PhoneCode = "0939" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "平凉", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "pingliang", PostCode = "744000", PhoneCode = "0933" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "庆阳", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "qingyang", PostCode = "745000", PhoneCode = "0934" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "天水", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "tianshui", PostCode = "741000", PhoneCode = "0938" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "武威", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "wuwei", PostCode = "733000", PhoneCode = "0935" });
            All.Add(new SmartArea() { Country = "中国", Province = "甘肃", City = "张掖", CountryPinyin = "zhongguo", ProvincePinyin = "gansu", CityPinyin = "zhangye", PostCode = "734000", PhoneCode = "0936" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "潮州", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "chaozhou", PostCode = "521000", PhoneCode = "0768" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "东莞", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "dongguan", PostCode = "523000", PhoneCode = "0769" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "佛山", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "foshan", PostCode = "528000", PhoneCode = "0757" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "广州", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "guangzhou", PostCode = "510000", PhoneCode = "020" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "河源", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "heyuan", PostCode = "517000", PhoneCode = "0762" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "惠州", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "huizhou", PostCode = "516000", PhoneCode = "0752" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "江门", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "jiangmen", PostCode = "529000", PhoneCode = "0750" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "揭阳", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "jieyang", PostCode = "522000", PhoneCode = "0663" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "茂名", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "maoming", PostCode = "525000", PhoneCode = "0668" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "梅州", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "meizhou", PostCode = "514000", PhoneCode = "0753" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "清远", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "qingyuan", PostCode = "511500", PhoneCode = "0763" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "汕头", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "shantou", PostCode = "515000", PhoneCode = "0754" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "汕尾", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "shanwei", PostCode = "516600", PhoneCode = "0660" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "韶关", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "shaoguan", PostCode = "512000", PhoneCode = "0751" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "深圳", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "shenzhen", PostCode = "518000", PhoneCode = "0755" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "阳江", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "yangjiang", PostCode = "529500", PhoneCode = "0662" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "云浮", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "yunfu", PostCode = "527300", PhoneCode = "0766" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "湛江", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "zhanjiang", PostCode = "524000", PhoneCode = "0759" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "肇庆", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "zhaoqing", PostCode = "526000", PhoneCode = "0758" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "中山", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "zhongshan", PostCode = "528400", PhoneCode = "0760" });
            All.Add(new SmartArea() { Country = "中国", Province = "广东", City = "珠海", CountryPinyin = "zhongguo", ProvincePinyin = "guangdong", CityPinyin = "zhuhai", PostCode = "519000", PhoneCode = "0756" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "百色", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "baise", PostCode = "533000", PhoneCode = "0776" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "北海", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "beihai", PostCode = "536000", PhoneCode = "0779" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "崇左", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "chongzuo", PostCode = "532200", PhoneCode = "0771" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "防城港", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "fangchenggang", PostCode = "538000", PhoneCode = "0770" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "贵港", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "guigang", PostCode = "537100", PhoneCode = "0775" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "桂林", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "guilin", PostCode = "541000", PhoneCode = "0773" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "河池", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "hechi", PostCode = "547000", PhoneCode = "0778" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "贺州", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "hezhou", PostCode = "542800", PhoneCode = "0774" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "来宾", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "laibin", PostCode = "546100", PhoneCode = "0772" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "柳州", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "liuzhou", PostCode = "545000", PhoneCode = "0772" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "南宁", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "naning", PostCode = "530000", PhoneCode = "0771" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "钦州", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "qinzhou", PostCode = "535000", PhoneCode = "0777" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "梧州", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "wuzhou", PostCode = "543000", PhoneCode = "0774" });
            All.Add(new SmartArea() { Country = "中国", Province = "广西", City = "玉林", CountryPinyin = "zhongguo", ProvincePinyin = "guangxi", CityPinyin = "yulin", PostCode = "537000", PhoneCode = "0775" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "安顺", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "anshun", PostCode = "561000", PhoneCode = "0853" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "毕节", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "bijie", PostCode = "551700", PhoneCode = "0857" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "都匀", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "duyun", PostCode = "558000", PhoneCode = "0854" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "贵阳", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "guiyang", PostCode = "550000", PhoneCode = "0851" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "凯里", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "kaili", PostCode = "556000", PhoneCode = "0855" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "六盘水", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "liupanshui", PostCode = "553000", PhoneCode = "0858" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "黔东南", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "qiandongnan", PostCode = "556000", PhoneCode = "0855" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "黔南", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "qiannan", PostCode = "558000", PhoneCode = "0854" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "黔西南", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "qianxinan", PostCode = "562400", PhoneCode = "0859" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "铜仁", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "tongren", PostCode = "554300", PhoneCode = "0856" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "兴义", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "xingyi", PostCode = "562400", PhoneCode = "0859" });
            All.Add(new SmartArea() { Country = "中国", Province = "贵州", City = "遵义", CountryPinyin = "zhongguo", ProvincePinyin = "guizhou", CityPinyin = "zunyi", PostCode = "563000", PhoneCode = "0852" });
            All.Add(new SmartArea() { Country = "中国", Province = "海南", City = "海口", CountryPinyin = "zhongguo", ProvincePinyin = "hainan", CityPinyin = "haikou", PostCode = "570100", PhoneCode = "0898" });
            All.Add(new SmartArea() { Country = "中国", Province = "海南", City = "三亚", CountryPinyin = "zhongguo", ProvincePinyin = "hainan", CityPinyin = "sanya", PostCode = "572000", PhoneCode = "0898" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "保定", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "baoding", PostCode = "071000", PhoneCode = "0312" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "沧州", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "cangzhou", PostCode = "061000", PhoneCode = "0317" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "承德", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "chengde", PostCode = "067000", PhoneCode = "0314" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "邯郸", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "handan", PostCode = "056000", PhoneCode = "0310" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "衡水", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "hengshui", PostCode = "053000", PhoneCode = "0318" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "廊坊", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "langfang", PostCode = "065000", PhoneCode = "0316" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "秦皇岛", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "qinhuangdao", PostCode = "066000", PhoneCode = "0335" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "石家庄", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "shijiazhuang", PostCode = "050000", PhoneCode = "0311" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "唐山", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "tangshan", PostCode = "063000", PhoneCode = "0315" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "邢台", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "xingtai", PostCode = "054000", PhoneCode = "0319" });
            All.Add(new SmartArea() { Country = "中国", Province = "河北", City = "张家口", CountryPinyin = "zhongguo", ProvincePinyin = "hebei", CityPinyin = "zhangjiakou", PostCode = "075000", PhoneCode = "0313" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "安阳", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "anyang", PostCode = "455000", PhoneCode = "0372" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "鹤壁", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "hebi", PostCode = "458000", PhoneCode = "0392" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "潢川", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "huangchuan", PostCode = "465100", PhoneCode = "0376" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "济源", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "jiyuan", PostCode = "454650", PhoneCode = "0391" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "焦作", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "jiaozuo", PostCode = "454100", PhoneCode = "0391" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "开封", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "kaifeng", PostCode = "475000", PhoneCode = "0371" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "洛阳", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "luoyang", PostCode = "471000", PhoneCode = "0379" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "漯河", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "luohe", PostCode = "462000", PhoneCode = "0395" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "南阳", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "nanyang", PostCode = "473000", PhoneCode = "0377" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "平顶山", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "pingdingshan", PostCode = "467000", PhoneCode = "0375" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "濮阳", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "puyang", PostCode = "457000", PhoneCode = "0393" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "三门峡", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "sanmenxia", PostCode = "472000", PhoneCode = "0398" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "商丘", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "shangqiu", PostCode = "476000", PhoneCode = "0370" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "新乡", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "xinxiang", PostCode = "453000", PhoneCode = "0373" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "信阳", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "xinyang", PostCode = "464000", PhoneCode = "0376" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "许昌", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "xuchang", PostCode = "461000", PhoneCode = "0374" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "郑州", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "zhengzhou", PostCode = "450000", PhoneCode = "0371" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "周口", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "zhoukou", PostCode = "466000", PhoneCode = "0394" });
            All.Add(new SmartArea() { Country = "中国", Province = "河南", City = "驻马店", CountryPinyin = "zhongguo", ProvincePinyin = "henan", CityPinyin = "zhumadian", PostCode = "463000", PhoneCode = "0396" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "大庆", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "daqing", PostCode = "163000", PhoneCode = "0459" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "大兴安岭", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "daxinganling", PostCode = "165000", PhoneCode = "0457" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "哈尔滨", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "haerbin", PostCode = "150000", PhoneCode = "0451" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "鹤岗", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "hegang", PostCode = "154100", PhoneCode = "0468" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "黑河", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "heihe", PostCode = "164300", PhoneCode = "0456" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "鸡西", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "jixi", PostCode = "158100", PhoneCode = "0467" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "佳木斯", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "jiamusi", PostCode = "154000", PhoneCode = "0454" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "牡丹江", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "mudanjiang", PostCode = "157000", PhoneCode = "0453" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "七台河", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "qitaihe", PostCode = "154600", PhoneCode = "0464" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "齐齐哈尔", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "qiqihaer", PostCode = "161000", PhoneCode = "0452" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "双鸭山", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "shuangyashan", PostCode = "155100", PhoneCode = "0469" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "绥化", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "suihua", PostCode = "152000", PhoneCode = "0455" });
            All.Add(new SmartArea() { Country = "中国", Province = "黑龙江", City = "伊春", CountryPinyin = "zhongguo", ProvincePinyin = "heilongjiang", CityPinyin = "yichun", PostCode = "153000", PhoneCode = "0458" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "鄂州", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "ezhou", PostCode = "436000", PhoneCode = "0711" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "恩施", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "enshi", PostCode = "445000", PhoneCode = "0718" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "黄冈", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "huanggang", PostCode = "438000", PhoneCode = "0713" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "黄石", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "huangshi", PostCode = "435000", PhoneCode = "0714" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "江汉", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "jianghan", PostCode = "430000", PhoneCode = "027" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "荆门", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "jingmen", PostCode = "448000", PhoneCode = "0724" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "荆州", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "jingzhou", PostCode = "434000", PhoneCode = "0716" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "十堰", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "shiyan", PostCode = "442000", PhoneCode = "0719" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "随州", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "suizhou", PostCode = "441300", PhoneCode = "0722" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "武汉", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "wuhan", PostCode = "430000", PhoneCode = "027" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "仙桃", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "xiantao", PostCode = "433000", PhoneCode = "0728" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "咸宁", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "xianning", PostCode = "437000", PhoneCode = "0715" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "襄阳", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "xiangyang", PostCode = "441000", PhoneCode = "0710" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "孝感", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "xiaogan", PostCode = "432000", PhoneCode = "0712" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖北", City = "宜昌", CountryPinyin = "zhongguo", ProvincePinyin = "hubei", CityPinyin = "yichang", PostCode = "443000", PhoneCode = "0717" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "长沙", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "changsha", PostCode = "410000", PhoneCode = "0731" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "常德", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "changde", PostCode = "415000", PhoneCode = "0736" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "郴州", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "chenzhou", PostCode = "423000", PhoneCode = "0735" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "衡阳", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "hengyang", PostCode = "421000", PhoneCode = "0734" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "怀化", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "huaihua", PostCode = "418000", PhoneCode = "0745" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "吉首", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "jishou", PostCode = "416000", PhoneCode = "0743" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "娄底", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "loudi", PostCode = "417000", PhoneCode = "0738" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "邵阳", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "shaoyang", PostCode = "422000", PhoneCode = "0739" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "湘潭", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "xiangtan", PostCode = "411100", PhoneCode = "0731" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "湘西", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "xiangxi", PostCode = "416000", PhoneCode = "0743" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "益阳", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "yiyang", PostCode = "413000", PhoneCode = "0737" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "永州", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "yongzhou", PostCode = "425000", PhoneCode = "0746" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "岳阳", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "yueyang", PostCode = "414000", PhoneCode = "0730" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "张家界", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "zhangjiajie", PostCode = "427000", PhoneCode = "0744" });
            All.Add(new SmartArea() { Country = "中国", Province = "湖南", City = "株洲", CountryPinyin = "zhongguo", ProvincePinyin = "hunan", CityPinyin = "zhuzhou", PostCode = "412000", PhoneCode = "0731" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "白城", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "baicheng", PostCode = "137000", PhoneCode = "0436" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "白山", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "baishan", PostCode = "134300", PhoneCode = "0439" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "长春", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "changchun", PostCode = "130000", PhoneCode = "0431" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "珲春", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "huichun", PostCode = "133300", PhoneCode = "0433" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "吉林", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "jilin", PostCode = "132000", PhoneCode = "0432" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "辽源", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "liaoyuan", PostCode = "136200", PhoneCode = "0437" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "梅河口", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "meihekou", PostCode = "135000", PhoneCode = "0435" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "四平", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "siping", PostCode = "136000", PhoneCode = "0434" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "松原", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "songyuan", PostCode = "138000", PhoneCode = "0438" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "通化", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "tonghua", PostCode = "134000", PhoneCode = "0435" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "延边", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "yanbian", PostCode = "133000", PhoneCode = "0433" });
            All.Add(new SmartArea() { Country = "中国", Province = "吉林", City = "延吉", CountryPinyin = "zhongguo", ProvincePinyin = "jilin", CityPinyin = "yanji", PostCode = "133000", PhoneCode = "0433" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "常州", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "changzhou", PostCode = "213000", PhoneCode = "0519" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "淮安", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "huaian", PostCode = "223001", PhoneCode = "0517" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "连云港", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "lianyungang", PostCode = "222000", PhoneCode = "0518" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "南京", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "nanjing", PostCode = "210000", PhoneCode = "025" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "南通", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "nantong", PostCode = "226000", PhoneCode = "0513" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "苏州", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "suzhou", PostCode = "215000", PhoneCode = "0512" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "宿迁", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "suqian", PostCode = "223800", PhoneCode = "0527" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "泰州", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "taizhou", PostCode = "225300", PhoneCode = "0523" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "无锡", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "wuxi", PostCode = "214000", PhoneCode = "0510" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "徐州", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "xuzhou", PostCode = "221000", PhoneCode = "0516" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "盐城", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "yancheng", PostCode = "224000", PhoneCode = "0515" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "扬州", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "yangzhou", PostCode = "225000", PhoneCode = "0514" });
            All.Add(new SmartArea() { Country = "中国", Province = "江苏", City = "镇江", CountryPinyin = "zhongguo", ProvincePinyin = "jiangsu", CityPinyin = "zhenjiang", PostCode = "212000", PhoneCode = "0511" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "抚州", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "fuzhou", PostCode = "344000", PhoneCode = "0794" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "赣州", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "ganzhou", PostCode = "341000", PhoneCode = "0797" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "吉安", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "jian", PostCode = "343000", PhoneCode = "0796" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "景德镇", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "jingdezhen", PostCode = "333000", PhoneCode = "0798" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "九江", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "jiujiang", PostCode = "332000", PhoneCode = "0792" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "南昌", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "nanchang", PostCode = "330000", PhoneCode = "0791" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "萍乡", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "pingxiang", PostCode = "337000", PhoneCode = "0799" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "上饶", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "shangrao", PostCode = "334000", PhoneCode = "0793" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "新余", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "xinyu", PostCode = "338000", PhoneCode = "0790" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "宜春", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "yichun", PostCode = "336000", PhoneCode = "0795" });
            All.Add(new SmartArea() { Country = "中国", Province = "江西", City = "鹰潭", CountryPinyin = "zhongguo", ProvincePinyin = "jiangxi", CityPinyin = "yingtan", PostCode = "335000", PhoneCode = "0701" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "鞍山", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "anshan", PostCode = "114000", PhoneCode = "0412" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "本溪", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "benxi", PostCode = "117000", PhoneCode = "0414" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "朝阳", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "chaoyang", PostCode = "122000", PhoneCode = "0421" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "大连", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "dalian", PostCode = "116000", PhoneCode = "0411" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "丹东", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "dandong", PostCode = "118000", PhoneCode = "0415" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "抚顺", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "fushun", PostCode = "113000", PhoneCode = "024" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "阜新", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "fuxin", PostCode = "123000", PhoneCode = "0418" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "葫芦岛", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "huludao", PostCode = "125000", PhoneCode = "0429" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "锦州", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "jinzhou", PostCode = "121000", PhoneCode = "0416" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "辽阳", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "liaoyang", PostCode = "111000", PhoneCode = "0419" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "盘锦", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "panjin", PostCode = "124000", PhoneCode = "0427" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "沈阳", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "shenyang", PostCode = "110000", PhoneCode = "024" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "铁岭", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "tieling", PostCode = "112000", PhoneCode = "024" });
            All.Add(new SmartArea() { Country = "中国", Province = "辽宁", City = "营口", CountryPinyin = "zhongguo", ProvincePinyin = "liaoning", CityPinyin = "yingkou", PostCode = "115000", PhoneCode = "0417" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "阿拉善盟", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "alashanmeng", PostCode = "737300", PhoneCode = "0483" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "巴彦淖尔", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "bayannaoer", PostCode = "015000", PhoneCode = "0478" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "包头", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "baotou", PostCode = "014000", PhoneCode = "0472" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "赤峰", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "chifeng", PostCode = "024000", PhoneCode = "0476" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "东胜", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "dongsheng", PostCode = "017000", PhoneCode = "0477" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "鄂尔多斯", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "eerduosi", PostCode = "017000", PhoneCode = "0477" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "海拉尔", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "hailaer", PostCode = "021000", PhoneCode = "0470" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "呼和浩特", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "huhehaote", PostCode = "010000", PhoneCode = "0471" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "呼伦贝尔", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "hulunbeier", PostCode = "021000", PhoneCode = "0470" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "集宁", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "jining", PostCode = "012000", PhoneCode = "0474" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "临河", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "linhe", PostCode = "015000", PhoneCode = "0478" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "通辽", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "tongliao", PostCode = "028000", PhoneCode = "0475" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "乌海", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "wuhai", PostCode = "016000", PhoneCode = "0473" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "乌兰察布", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "wulanchabu", PostCode = "012000", PhoneCode = "0474" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "乌兰浩特", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "wulanhaote", PostCode = "137400", PhoneCode = "0482" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "锡林郭勒盟", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "xilinguolemeng", PostCode = "026000", PhoneCode = "0479" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "锡林浩特", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "xilinhaote", PostCode = "026000", PhoneCode = "0479" });
            All.Add(new SmartArea() { Country = "中国", Province = "内蒙古", City = "兴安盟", CountryPinyin = "zhongguo", ProvincePinyin = "neimenggu", CityPinyin = "xinganmeng", PostCode = "137400", PhoneCode = "0482" });
            All.Add(new SmartArea() { Country = "中国", Province = "宁夏", City = "固原", CountryPinyin = "zhongguo", ProvincePinyin = "ningxia", CityPinyin = "guyuan", PostCode = "756000", PhoneCode = "0954" });
            All.Add(new SmartArea() { Country = "中国", Province = "宁夏", City = "石嘴山", CountryPinyin = "zhongguo", ProvincePinyin = "ningxia", CityPinyin = "shizuishan", PostCode = "753000", PhoneCode = "0952" });
            All.Add(new SmartArea() { Country = "中国", Province = "宁夏", City = "吴忠", CountryPinyin = "zhongguo", ProvincePinyin = "ningxia", CityPinyin = "wuzhong", PostCode = "751100", PhoneCode = "0953" });
            All.Add(new SmartArea() { Country = "中国", Province = "宁夏", City = "银川", CountryPinyin = "zhongguo", ProvincePinyin = "ningxia", CityPinyin = "yinchuan", PostCode = "750000", PhoneCode = "0951" });
            All.Add(new SmartArea() { Country = "中国", Province = "宁夏", City = "中卫", CountryPinyin = "zhongguo", ProvincePinyin = "ningxia", CityPinyin = "zhongwei", PostCode = "755000", PhoneCode = "0955" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "德令哈", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "delingha", PostCode = "817000", PhoneCode = "0977" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "格尔木", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "geermu", PostCode = "816000", PhoneCode = "0979" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "共和", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "gonghe", PostCode = "813000", PhoneCode = "0974" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "果洛", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "guoluo", PostCode = "814000", PhoneCode = "0975" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "海北", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "haibei", PostCode = "812200", PhoneCode = "0970" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "海东", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "haidong", PostCode = "810600", PhoneCode = "0972" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "海南", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "hainan", PostCode = "813000", PhoneCode = "0974" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "海西", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "haixi", PostCode = "817000", PhoneCode = "0979" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "海晏", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "haiyan", PostCode = "812200", PhoneCode = "0970" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "黄南", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "huangnan", PostCode = "811300", PhoneCode = "0973" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "西宁", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "xining", PostCode = "810000", PhoneCode = "0971" });
            All.Add(new SmartArea() { Country = "中国", Province = "青海", City = "玉树", CountryPinyin = "zhongguo", ProvincePinyin = "qinghai", CityPinyin = "yushu", PostCode = "815000", PhoneCode = "0976" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "滨州", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "binzhou", PostCode = "256600", PhoneCode = "0543" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "德州", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "dezhou", PostCode = "253000", PhoneCode = "0534" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "东营", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "dongying", PostCode = "257000", PhoneCode = "0546" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "菏泽", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "heze", PostCode = "274000", PhoneCode = "0530" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "济南", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "jinan", PostCode = "250000", PhoneCode = "0531" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "济宁", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "jining", PostCode = "272000", PhoneCode = "0537" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "莱芜", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "laiwu", PostCode = "271100", PhoneCode = "0634" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "聊城", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "liaocheng", PostCode = "252000", PhoneCode = "0635" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "临沂", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "linyi", PostCode = "276000", PhoneCode = "0539" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "青岛", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "qingdao", PostCode = "266000", PhoneCode = "0532" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "日照", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "rizhao", PostCode = "276800", PhoneCode = "0633" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "泰安", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "taian", PostCode = "271000", PhoneCode = "0538" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "威海", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "weihai", PostCode = "264200", PhoneCode = "0631" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "潍坊", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "weifang", PostCode = "261000", PhoneCode = "0536" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "烟台", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "yantai", PostCode = "264000", PhoneCode = "0535" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "枣庄", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "zaozhuang", PostCode = "277000", PhoneCode = "0632" });
            All.Add(new SmartArea() { Country = "中国", Province = "山东", City = "淄博", CountryPinyin = "zhongguo", ProvincePinyin = "shandong", CityPinyin = "zibo", PostCode = "255000", PhoneCode = "0533" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "长治", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "changzhi", PostCode = "046000", PhoneCode = "0355" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "大同", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "datong", PostCode = "037000", PhoneCode = "0352" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "晋城", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "jincheng", PostCode = "048000", PhoneCode = "0356" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "晋中", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "jinzhong", PostCode = "030600", PhoneCode = "0354" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "临汾", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "linfen", PostCode = "041000", PhoneCode = "0357" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "吕梁", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "lvliang", PostCode = "033000", PhoneCode = "0358" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "朔州", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "shuozhou", PostCode = "036000", PhoneCode = "0349" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "太原", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "taiyuan", PostCode = "030000", PhoneCode = "0351" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "忻州", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "xinzhou", PostCode = "034000", PhoneCode = "0350" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "阳泉", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "yangquan", PostCode = "045000", PhoneCode = "0353" });
            All.Add(new SmartArea() { Country = "中国", Province = "山西", City = "运城", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "yuncheng", PostCode = "044000", PhoneCode = "0359" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "安康", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "ankang", PostCode = "725000", PhoneCode = "0915" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "宝鸡", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "baoji", PostCode = "721000", PhoneCode = "0917" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "汉中", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "hanzhong", PostCode = "723000", PhoneCode = "0916" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "商洛", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "shangluo", PostCode = "726000", PhoneCode = "0914" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "商州", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "shangzhou", PostCode = "726000", PhoneCode = "0914" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "铜川", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "tongchuan", PostCode = "727000", PhoneCode = "0919" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "渭南", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "weinan", PostCode = "714000", PhoneCode = "0913" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "西安", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "xian", PostCode = "710000", PhoneCode = "029" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "咸阳", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "xianyang", PostCode = "712000", PhoneCode = "029" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "延安", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "yanan", PostCode = "716000", PhoneCode = "0911" });
            All.Add(new SmartArea() { Country = "中国", Province = "陕西", City = "榆林", CountryPinyin = "zhongguo", ProvincePinyin = "shanxi", CityPinyin = "yulin", PostCode = "719000", PhoneCode = "0912" });
            All.Add(new SmartArea() { Country = "中国", Province = "上海", City = "上海", CountryPinyin = "zhongguo", ProvincePinyin = "shanghai", CityPinyin = "shanghai", PostCode = "200000", PhoneCode = "021" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "阿坝", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "aba", PostCode = "624000", PhoneCode = "0837" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "巴中", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "bazhong", PostCode = "636600", PhoneCode = "0827" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "成都", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "chengdu", PostCode = "610000", PhoneCode = "028" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "达州", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "dazhou", PostCode = "635000", PhoneCode = "0818" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "德阳", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "deyang", PostCode = "618000", PhoneCode = "0838" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "甘孜", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "ganzi", PostCode = "626000", PhoneCode = "0836" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "广安", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "guangan", PostCode = "638000", PhoneCode = "0826" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "广元", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "guangyuan", PostCode = "628000", PhoneCode = "0839" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "乐山", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "leshan", PostCode = "614000", PhoneCode = "0833" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "凉山", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "liangshan", PostCode = "615000", PhoneCode = "0834" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "泸州", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "luzhou", PostCode = "646000", PhoneCode = "0830" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "眉山", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "meishan", PostCode = "620000", PhoneCode = "028" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "绵阳", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "mianyang", PostCode = "621000", PhoneCode = "0816" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "内江", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "neijiang", PostCode = "641000", PhoneCode = "0832" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "南充", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "nanchong", PostCode = "637000", PhoneCode = "0817" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "攀枝花", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "panzhihua", PostCode = "617000", PhoneCode = "0812" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "遂宁", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "suining", PostCode = "629000", PhoneCode = "0825" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "西昌", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "xichang", PostCode = "615000", PhoneCode = "0834" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "雅安", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "yaan", PostCode = "625000", PhoneCode = "0835" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "宜宾", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "yibin", PostCode = "644000", PhoneCode = "0831" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "资阳", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "ziyang", PostCode = "641300", PhoneCode = "028" });
            All.Add(new SmartArea() { Country = "中国", Province = "四川", City = "自贡", CountryPinyin = "zhongguo", ProvincePinyin = "sichuan", CityPinyin = "zigong", PostCode = "643000", PhoneCode = "0813" });
            All.Add(new SmartArea() { Country = "中国", Province = "天津", City = "天津", CountryPinyin = "zhongguo", ProvincePinyin = "tianjin", CityPinyin = "tianjin", PostCode = "300000", PhoneCode = "022" });
            All.Add(new SmartArea() { Country = "中国", Province = "西藏", City = "阿里", CountryPinyin = "zhongguo", ProvincePinyin = "xizang", CityPinyin = "ali", PostCode = "859000", PhoneCode = "0897" });
            All.Add(new SmartArea() { Country = "中国", Province = "西藏", City = "昌都", CountryPinyin = "zhongguo", ProvincePinyin = "xizang", CityPinyin = "changdu", PostCode = "854000", PhoneCode = "0895" });
            All.Add(new SmartArea() { Country = "中国", Province = "西藏", City = "拉萨", CountryPinyin = "zhongguo", ProvincePinyin = "xizang", CityPinyin = "lasa", PostCode = "850000", PhoneCode = "0891" });
            All.Add(new SmartArea() { Country = "中国", Province = "西藏", City = "林芝", CountryPinyin = "zhongguo", ProvincePinyin = "xizang", CityPinyin = "linzhi", PostCode = "860000", PhoneCode = "0894" });
            All.Add(new SmartArea() { Country = "中国", Province = "西藏", City = "那曲", CountryPinyin = "zhongguo", ProvincePinyin = "xizang", CityPinyin = "naqu", PostCode = "852000", PhoneCode = "0896" });
            All.Add(new SmartArea() { Country = "中国", Province = "西藏", City = "日喀则", CountryPinyin = "zhongguo", ProvincePinyin = "xizang", CityPinyin = "rikaze", PostCode = "857000", PhoneCode = "0892" });
            All.Add(new SmartArea() { Country = "中国", Province = "西藏", City = "山南", CountryPinyin = "zhongguo", ProvincePinyin = "xizang", CityPinyin = "shannan", PostCode = "856000", PhoneCode = "0893" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "阿克苏", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "akesu", PostCode = "843000", PhoneCode = "0997" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "阿勒泰", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "aletai", PostCode = "836500", PhoneCode = "0906" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "阿图什", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "atushen", PostCode = "845300", PhoneCode = "0908" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "巴音郭楞", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "bayinguoleng", PostCode = "841000", PhoneCode = "0996" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "博尔塔拉", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "boertala", PostCode = "833400", PhoneCode = "0909" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "博乐", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "bole", PostCode = "833400", PhoneCode = "0909" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "昌吉", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "changji", PostCode = "831100", PhoneCode = "0994" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "哈密", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "hami", PostCode = "839000", PhoneCode = "0902" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "和田", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "hetian", PostCode = "848000", PhoneCode = "0903" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "喀什", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "kashen", PostCode = "844000", PhoneCode = "0998" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "克拉玛依", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "kelamayi", PostCode = "834000", PhoneCode = "0990" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "克州", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "kezhou", PostCode = "", PhoneCode = "" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "库尔勒", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "kuerle", PostCode = "841000", PhoneCode = "0996" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "奎屯", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "kuitun", PostCode = "833200", PhoneCode = "0992" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "石河子", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "shihezi", PostCode = "832000", PhoneCode = "0993" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "塔城", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "tacheng", PostCode = "834700", PhoneCode = "0901" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "吐鲁番", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "tulufan", PostCode = "838000", PhoneCode = "0995" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "乌鲁木齐", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "wulumuji", PostCode = "830000", PhoneCode = "0991" });
            All.Add(new SmartArea() { Country = "中国", Province = "新疆", City = "伊犁", CountryPinyin = "zhongguo", ProvincePinyin = "xinjiang", CityPinyin = "yili", PostCode = "835000", PhoneCode = "0999" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "保山", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "baoshan", PostCode = "678000", PhoneCode = "0875" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "楚雄", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "chuxiong", PostCode = "675000", PhoneCode = "0878" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "大理", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "dali", PostCode = "671000", PhoneCode = "0872" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "德宏", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "dehong", PostCode = "678400", PhoneCode = "0692" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "迪庆", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "diqing", PostCode = "674400", PhoneCode = "0887" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "红河", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "honghe", PostCode = "654400", PhoneCode = "0873" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "昆明", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "kunming", PostCode = "650000", PhoneCode = "0871" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "丽江", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "lijiang", PostCode = "674100", PhoneCode = "0888" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "临沧", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "lincang", PostCode = "677000", PhoneCode = "0883" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "怒江", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "nujiang", PostCode = "673100", PhoneCode = "0886" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "普洱", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "puer", PostCode = "665000", PhoneCode = "0879" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "曲靖", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "qujing", PostCode = "655000", PhoneCode = "0874" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "思茅", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "simao", PostCode = "665000", PhoneCode = "0879" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "文山", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "wenshan", PostCode = "663000", PhoneCode = "0876" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "西双版纳", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "xishuangbanna", PostCode = "666100", PhoneCode = "0691" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "玉溪", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "yuxi", PostCode = "653100", PhoneCode = "0877" });
            All.Add(new SmartArea() { Country = "中国", Province = "云南", City = "昭通", CountryPinyin = "zhongguo", ProvincePinyin = "yunnan", CityPinyin = "zhaotong", PostCode = "657000", PhoneCode = "0870" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "杭州", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "hangzhou", PostCode = "310000", PhoneCode = "0571" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "湖州", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "huzhou", PostCode = "313000", PhoneCode = "0572" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "嘉兴", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "jiaxing", PostCode = "314000", PhoneCode = "0573" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "金华", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "jinhua", PostCode = "321000", PhoneCode = "0579" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "丽水", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "lishui", PostCode = "323000", PhoneCode = "0578" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "宁波", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "ningbo", PostCode = "315000", PhoneCode = "0574" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "衢州", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "quzhou", PostCode = "324000", PhoneCode = "0570" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "绍兴", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "shaoxing", PostCode = "312000", PhoneCode = "0575" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "台州", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "taizhou", PostCode = "318000", PhoneCode = "0576" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "温州", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "wenzhou", PostCode = "325000", PhoneCode = "0577" });
            All.Add(new SmartArea() { Country = "中国", Province = "浙江", City = "舟山", CountryPinyin = "zhongguo", ProvincePinyin = "zhejiang", CityPinyin = "zhoushan", PostCode = "316000", PhoneCode = "0580" });
            All.Add(new SmartArea() { Country = "中国", Province = "重庆", City = "涪陵", CountryPinyin = "zhongguo", ProvincePinyin = "chongqing", CityPinyin = "fuling", PostCode = "408000", PhoneCode = "023" });
            All.Add(new SmartArea() { Country = "中国", Province = "重庆", City = "黔江", CountryPinyin = "zhongguo", ProvincePinyin = "chongqing", CityPinyin = "qianjiang", PostCode = "409000", PhoneCode = "023" });
            All.Add(new SmartArea() { Country = "中国", Province = "重庆", City = "万州", CountryPinyin = "zhongguo", ProvincePinyin = "chongqing", CityPinyin = "wanzhou", PostCode = "404000", PhoneCode = "023" });
            All.Add(new SmartArea() { Country = "中国", Province = "重庆", City = "重庆", CountryPinyin = "zhongguo", ProvincePinyin = "chongqing", CityPinyin = "chongqing", PostCode = "400000", PhoneCode = "023" });

        }

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 国家拼音
        /// </summary>
        public string CountryPinyin { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 省份拼音
        /// </summary>
        public string ProvincePinyin { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 城市拼音
        /// </summary>
        public string CityPinyin { get; set; }

        /// <summary>
        /// 电话区号
        /// </summary>
        public string PhoneCode { get; set; }

        /// <summary>
        /// 邮政编号
        /// </summary>
        public string PostCode { get; set; }
    }
}
