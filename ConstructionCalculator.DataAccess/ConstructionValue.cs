using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionCalculator.DataAccess.Interfaces;

namespace ConstructionCalculator.DataAccess
{
    public class ConstructionValue : IFile, IExport, IKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public File File { get; set; }

        [Display(Name = "名称")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "等级")] public ConstructionDesignRequirement DesignRequirement { get; set; }

        [Display(Name = "结构抗火时间，fs(min)")] public double Jgkhsj { get; set; }

        [Display(Name = "外墙抗火时间,ff(min)")] public double Wqkhsj { get; set; }

        [Display(Name = "屋顶和吊顶抗火时间,fd(min)")] public double Wdkhsj { get; set; }

        [Display(Name = "内墙抗火时间,fw(min)")] public double Nqkhsj { get; set; }

        [Display(Name = "平均抗火能力，f")] public double Pjkhnl { get; set; }

        [Display(Name = "结构抗火因子，F0")] public double Jgkhyz { get; set; }

        [Display(Name = "建筑抗火因子，F")] public double Jzkhyz { get; set; }

        public List<string> GetHeader()
        {
            return new List<string>
            {
                "名称",
                "等级",
                "结构抗火时间，fs(min)",
                "外墙抗火时间,ff(min)",
                "屋顶和吊顶抗火时间,fd(min)",
                "内墙抗火时间,fw(min)",
                "平均抗火能力，f",
                "结构抗火因子，F0",
                "建筑抗火因子，F"
            };
        }

        public List<object> GetRow()
        {
            return new List<object> { Name, DesignRequirement, Jgkhsj, Wqkhsj, Wdkhsj, Nqkhsj, Pjkhnl, Jgkhyz, Jzkhyz };
        }

        [ForeignKey("File")] public int? FileId { get; set; }
      
    }

    public enum ConstructionDesignRequirement
    {
        一级,
        二级,
        三级,
        四级
    }
}