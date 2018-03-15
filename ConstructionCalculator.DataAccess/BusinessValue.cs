using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConstructionCalculator.DataAccess
{
    public class BusinessValue
    {
        [Display(Name = "业态编号")]
        public int Id { get; set; }

        [Display(Name = "业态名称")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "业态特征编号")]
        public int FeatureId { get; set; }

        [Display(Name = "业态特征")]
        public string FeatureName { get; set; }

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
    }
}