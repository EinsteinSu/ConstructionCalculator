using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionCalculator.DataAccess.Interfaces;

namespace ConstructionCalculator.DataAccess
{
    public class BusinessValue : IFile, IExport, IKey
    {
        [Display(Name = "业态名称", Order = 1)] public string Name { get; set; }

        [Display(AutoGenerateField = false)] public File File { get; set; }

        public List<string> GetHeader()
        {
            return new List<string> { "业态编号", "业态名称" };
        }

        public List<object> GetRow()
        {
            return new List<object> { Id, Name };
        }

        [Display(AutoGenerateField = false)]
        [ForeignKey("File")]
        public int? FileId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "业态编号", Order = 0)]
        public int Id { get; set; }
    }

    public class BusinessFeature : IFile, IExport, IKey
    {
        [Display(AutoGenerateField = false)] public File File { get; set; }

        [Display(Name = "业态特征", Order = 1)] public string Name { get; set; }

        [Display(AutoGenerateField = false)]
        [ForeignKey("BusinessValue")]
        public int BusinessValueId { get; set; }

        [Display(AutoGenerateField = false)]
        public virtual BusinessValue BusinessValue { get; set; }

        [Display(Name = "固定,Qi", Order = 2)] public double GdQi { get; set; }

        [Display(Name = "移动,Qm", Order = 3)] public double YdQm { get; set; }

        [Display(Name = "火灾蔓延因子i", Order = 4)] public double Hzmyyzi { get; set; }

        [Display(Name = "活动因子a", Order = 5)] public double Hdyza { get; set; }

        [Display(Name = "依赖因子d", Order = 6)] public double Ylyzd { get; set; }

        [Display(Name = "疏散时间修正值P", Order = 7)] public double Sssjxzzp { get; set; }

        [Display(Name = "疏散人数密度*单层（单元）面积", Order = 8)] public double Ssrs { get; set; }

        [Display(Name = "价值因子", Order = 9)] public double Jzyz { get; set; }

        [Display(Name = "人口密度取值", Order = 10)] public double Rkmdqz { get; set; }

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

        [Display(AutoGenerateField = false)]
        [ForeignKey("File")]
        public int? FileId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "业态特征编号", Order = 0)]
        public int Id { get; set; }
    }
}