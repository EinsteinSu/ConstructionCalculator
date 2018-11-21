using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionCalculator.DataAccess.Interfaces;

namespace ConstructionCalculator.DataAccess
{
    public class Construction : IFile
    {
        public int Id { get; set; }

        public File File { get; set; }

        [ForeignKey("File")]
        public int? FileId { get; set; }

        [Display(Name = "建筑名称")] public string Jzmc { get; set; }

        [Display(Name = "单体编号")] public string Dtbh { get; set; }

       public virtual ConstructionValue ConstructionValue { get; set; }

        [Display(Name = "建筑结构编号")]
        [ForeignKey("ConstructionValue")]
        public int ConstructionValueId { get; set; }
        
        public virtual BusinessFeature BusinessFeature { get; set; }

        [Display(Name = "业态特征编号")]
        [ForeignKey("BusinessFeature")]
        public int BusinessFeatureId { get; set; }

        [Display(Name = "总建筑面积m2")] public string Jzmj { get; set; }

        [Display(Name = "单元单层建筑面积m2")] public double Dydcjzmj { get; set; }

        [Display(Name = "层数")] public int Cs { get; set; }

        [Display(Name = "高度m")] public double Gd { get; set; }

        [Display(Name = "单元单层安全出口数量")] public int Aqcksl { get; set; }

        [Display(Name = "单元单层安全出口宽度cm")] public double Aqckkd { get; set; }

        [Display(Name = "总出口数量")] public int Zcksl { get; set; }

        [Display(Name = "总出口宽度cm")] public string Zckkd { get; set; }

        [Display(Name = "水源、水池、水箱")] public int Sy { get; set; }

        [Display(Name = "灭火器")] public int Mhq { get; set; }

        [Display(Name = "室内栓")] public int Sns { get; set; }

        [Display(Name = "自动报警")] public int Zdbj { get; set; }

        [Display(Name = "喷淋")] public int Pl { get; set; }

        [Display(Name = "可临近面")] public int Kljm { get; set; }

        [Display(Name = "有无私拉乱接")] public int Ywsl { get; set; }

        [Display(Name = "有无维保记录")] public int Ywwbjl { get; set; }

        [Display(Name = "有/无有室外栓")] public int Ywsws { get; set; }

        [Display(Name = "室外栓内有/无水")] public int Swsyws { get; set; }

        [Display(Name = "室外栓最近距离 (m)")] public string Swsjl { get; set; }

        [Display(Name = "现役消防部队距片区距离(km)")] public double Xfdjl { get; set; }

        [Display(Name = "栋数")] public int Ds { get; set; }

    }
}