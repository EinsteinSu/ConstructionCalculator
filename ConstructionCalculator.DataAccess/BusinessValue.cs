using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCalculator.DataAccess
{
    public class BusinessValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "业态编号")]
        public int Id { get; set; }

        [Display(Name = "业态名称")]
        public string Name { get; set; }

    }

    public class BusinessFeature
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }


        [Display(Name = "业态特征")]
        public string Name { get; set; }

        [ForeignKey("BusinessValue")]
        public int BusinessValueId { get; set; }

        public virtual BusinessValue BusinessValue { get; set; }

        [Display(Name = "固定,Qi")]
        public double GdQi { get; set; }

        [Display(Name = "移动,Qm")]
        public double YdQm { get; set; }

        [Display(Name = "火灾蔓延因子i")]
        public double Hzmyyzi { get; set; }

        [Display(Name = "活动因子a")]
        public double Hdyza { get; set; }

        [Display(Name = "依赖因子d")]
        public double Ylyzd { get; set; }

        [Display(Name = "疏散时间修正值P")]
        public double Sssjxzzp { get; set; }

        [Display(Name = "疏散人数密度*单层（单元）面积")]
        public double Ssrs { get; set; }

        [Display(Name = "价值因子")]
        public double Jzyz { get; set; }

        public virtual ObservableCollection<Construction> Constructions { get; set; }

    }
}