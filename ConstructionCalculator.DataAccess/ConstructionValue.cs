using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCalculator.DataAccess
{
    public class ConstructionValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ConstructionDesignRequirement DesignRequirement { get; set; }

        [Display(Name = "结构抗火时间，fs(min)")]
        public double Jgkhsj { get; set; }

        [Display(Name = "外墙抗火时间,ff（min）")]
        public double Wqkhsj { get; set; }

        [Display(Name = "屋顶和吊顶抗火时间,fd（min）")]
        public double Wdkhsj { get; set; }

        [Display(Name = "内墙抗火时间,fw（min）")]
        public double Nqkhsj { get; set; }

        [Display(Name = "平均抗火能力，f")]
        public double Pjkhnl { get; set; }

        [Display(Name = "结构抗火因子，F0")]
        public double Jgkhyz { get; set; }

        [Display(Name = "建筑抗火因子，F")]
        public double Jzkhyz { get; set; }
    }

    public enum ConstructionDesignRequirement
    {
        一级,
        二级,
        三级,
        四级
    }
}