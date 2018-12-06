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
        [Display(Name = "建筑结构编号", Order = 0)]
        public int Id { get; set; }
        [Display(AutoGenerateField = false)] public File File { get; set; }

        [Display(Name = "名称", Order = 1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "等级", Order = 2)] public ConstructionDesignRequirement DesignRequirement { get; set; }

        [Display(Name = "结构抗火时间，fs(min)", Order = 3)] public double Jgkhsj { get; set; }

        [Display(Name = "外墙抗火时间,ff(min)", Order = 4)] public double Wqkhsj { get; set; }

        [Display(Name = "屋顶和吊顶抗火时间,fd(min)", Order = 5)] public double Wdkhsj { get; set; }

        [Display(Name = "内墙抗火时间,fw(min)", Order = 6)] public double Nqkhsj { get; set; }

        [Display(Name = "平均抗火能力，f", Order = 7)] public double Pjkhnl { get; set; }

        [Display(Name = "结构抗火因子，F0", Order = 8)] public double Jgkhyz { get; set; }

        [Display(Name = "建筑抗火因子，F", Order = 9)] public double Jzkhyz { get; set; }

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

        [Display(AutoGenerateField = false)]
        [ForeignKey("File")]
        public int? FileId { get; set; }

    }

    public enum ConstructionDesignRequirement
    {
        一级,
        二级,
        三级,
        四级
    }
}