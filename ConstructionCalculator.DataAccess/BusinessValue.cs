using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionCalculator.DataAccess.Interfaces;

namespace ConstructionCalculator.DataAccess
{
    public class BusinessValue : IFile, IExport,ICreate<BusinessValue>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "业态编号")]
        public int Id { get; set; }

        [Display(Name = "业态名称")] public string Name { get; set; }

        public File File { get; set; }

        public List<string> GetHeader()
        {
            return new List<string> { "业态编号", "业态名称" };
        }

        public List<object> GetRow()
        {
            return new List<object> { Id, Name };
        }

        [ForeignKey("File")] public int? FileId { get; set; }
        public BusinessValue CreateItem()
        {
            return new BusinessValue();
        }
    }

    public class BusinessFeature : IFile, IExport,ICreate<BusinessFeature>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "业态特征编号")]
        public int Id { get; set; }

        public File File { get; set; }

        [Display(Name = "业态特征")] public string Name { get; set; }

        [ForeignKey("BusinessValue")] public int BusinessValueId { get; set; }

        public virtual BusinessValue BusinessValue { get; set; }

        [Display(Name = "固定,Qi")] public double GdQi { get; set; }

        [Display(Name = "移动,Qm")] public double YdQm { get; set; }

        [Display(Name = "火灾蔓延因子i")] public double Hzmyyzi { get; set; }

        [Display(Name = "活动因子a")] public double Hdyza { get; set; }

        [Display(Name = "依赖因子d")] public double Ylyzd { get; set; }

        [Display(Name = "疏散时间修正值P")] public double Sssjxzzp { get; set; }

        [Display(Name = "疏散人数密度*单层（单元）面积")] public double Ssrs { get; set; }

        [Display(Name = "价值因子")] public double Jzyz { get; set; }

        [Display(Name = "人口密度取值")] public double Rkmdqz { get; set; }

        public virtual ObservableCollection<Construction> Constructions { get; set; }

        public List<string> GetHeader()
        {
            return new List<string>
            {
                "业态特征编号",
                "业态特征",
                "固定,Qi",
                "移动,Qm",
                "火灾蔓延因子i",
                "活动因子a",
                "依赖因子d",
                "疏散时间修正值P",
                "疏散人数密度*单层（单元）面积",
                "价值因子",
                "人口密度取值"
            };
        }

        public List<object> GetRow()
        {
            return new List<object> { Id, Name, GdQi, YdQm, Hzmyyzi, Hdyza, Ylyzd, Sssjxzzp, Ssrs, Jzyz, Rkmdqz };
        }

        [ForeignKey("File")] public int? FileId { get; set; }
        public BusinessFeature CreateItem()
        {
            return new BusinessFeature();
        }
    }
}