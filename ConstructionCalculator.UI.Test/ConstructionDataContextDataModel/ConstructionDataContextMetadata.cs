using ConstructionCalculator.DataAccess;
using ConstructionCalculator.UI.Test.Localization;
using DevExpress.Mvvm.DataAnnotations;

namespace ConstructionCalculator.UI.Test.ConstructionDataContextDataModel {

    public class ConstructionDataContextMetadataProvider {
		        public static void BuildMetadata(MetadataBuilder<BusinessFeature> builder) {
			builder.DisplayName(ConstructionDataContextResources.BusinessFeature);
						builder.Property(x => x.Id).DisplayName(ConstructionDataContextResources.BusinessFeature_Id);
						builder.Property(x => x.Name).DisplayName(ConstructionDataContextResources.BusinessFeature_Name);
						builder.Property(x => x.GdQi).DisplayName(ConstructionDataContextResources.BusinessFeature_GdQi);
						builder.Property(x => x.YdQm).DisplayName(ConstructionDataContextResources.BusinessFeature_YdQm);
						builder.Property(x => x.Hzmyyzi).DisplayName(ConstructionDataContextResources.BusinessFeature_Hzmyyzi);
						builder.Property(x => x.Hdyza).DisplayName(ConstructionDataContextResources.BusinessFeature_Hdyza);
						builder.Property(x => x.Ylyzd).DisplayName(ConstructionDataContextResources.BusinessFeature_Ylyzd);
						builder.Property(x => x.Sssjxzzp).DisplayName(ConstructionDataContextResources.BusinessFeature_Sssjxzzp);
						builder.Property(x => x.Ssrs).DisplayName(ConstructionDataContextResources.BusinessFeature_Ssrs);
						builder.Property(x => x.Jzyz).DisplayName(ConstructionDataContextResources.BusinessFeature_Jzyz);
						builder.Property(x => x.Rkmdqz).DisplayName(ConstructionDataContextResources.BusinessFeature_Rkmdqz);
						builder.Property(x => x.BusinessValue).DisplayName(ConstructionDataContextResources.BusinessFeature_BusinessValue);
						builder.Property(x => x.File).DisplayName(ConstructionDataContextResources.BusinessFeature_File);
			        }
		        public static void BuildMetadata(MetadataBuilder<BusinessValue> builder) {
			builder.DisplayName(ConstructionDataContextResources.BusinessValue);
						builder.Property(x => x.Id).DisplayName(ConstructionDataContextResources.BusinessValue_Id);
						builder.Property(x => x.Name).DisplayName(ConstructionDataContextResources.BusinessValue_Name);
						builder.Property(x => x.File).DisplayName(ConstructionDataContextResources.BusinessValue_File);
			        }
		        public static void BuildMetadata(MetadataBuilder<File> builder) {
			builder.DisplayName(ConstructionDataContextResources.File);
						builder.Property(x => x.Id).DisplayName(ConstructionDataContextResources.File_Id);
						builder.Property(x => x.FileName).DisplayName(ConstructionDataContextResources.File_FileName);
						builder.Property(x => x.Type).DisplayName(ConstructionDataContextResources.File_Type);
						builder.Property(x => x.Description).DisplayName(ConstructionDataContextResources.File_Description);
			        }
		        public static void BuildMetadata(MetadataBuilder<Construction> builder) {
			builder.DisplayName(ConstructionDataContextResources.Construction);
						builder.Property(x => x.Id).DisplayName(ConstructionDataContextResources.Construction_Id);
						builder.Property(x => x.Jzmc).DisplayName(ConstructionDataContextResources.Construction_Jzmc);
						builder.Property(x => x.Dtbh).DisplayName(ConstructionDataContextResources.Construction_Dtbh);
						builder.Property(x => x.Jzmj).DisplayName(ConstructionDataContextResources.Construction_Jzmj);
						builder.Property(x => x.Dydcjzmj).DisplayName(ConstructionDataContextResources.Construction_Dydcjzmj);
						builder.Property(x => x.Cs).DisplayName(ConstructionDataContextResources.Construction_Cs);
						builder.Property(x => x.Gd).DisplayName(ConstructionDataContextResources.Construction_Gd);
						builder.Property(x => x.Aqcksl).DisplayName(ConstructionDataContextResources.Construction_Aqcksl);
						builder.Property(x => x.Aqckkd).DisplayName(ConstructionDataContextResources.Construction_Aqckkd);
						builder.Property(x => x.Zcksl).DisplayName(ConstructionDataContextResources.Construction_Zcksl);
						builder.Property(x => x.Zckkd).DisplayName(ConstructionDataContextResources.Construction_Zckkd);
						builder.Property(x => x.Sy).DisplayName(ConstructionDataContextResources.Construction_Sy);
						builder.Property(x => x.Mhq).DisplayName(ConstructionDataContextResources.Construction_Mhq);
						builder.Property(x => x.Sns).DisplayName(ConstructionDataContextResources.Construction_Sns);
						builder.Property(x => x.Zdbj).DisplayName(ConstructionDataContextResources.Construction_Zdbj);
						builder.Property(x => x.Pl).DisplayName(ConstructionDataContextResources.Construction_Pl);
						builder.Property(x => x.Kljm).DisplayName(ConstructionDataContextResources.Construction_Kljm);
						builder.Property(x => x.Ywsl).DisplayName(ConstructionDataContextResources.Construction_Ywsl);
						builder.Property(x => x.Ywwbjl).DisplayName(ConstructionDataContextResources.Construction_Ywwbjl);
						builder.Property(x => x.Ywsws).DisplayName(ConstructionDataContextResources.Construction_Ywsws);
						builder.Property(x => x.Swsyws).DisplayName(ConstructionDataContextResources.Construction_Swsyws);
						builder.Property(x => x.Swsjl).DisplayName(ConstructionDataContextResources.Construction_Swsjl);
						builder.Property(x => x.Xfdjl).DisplayName(ConstructionDataContextResources.Construction_Xfdjl);
						builder.Property(x => x.Ds).DisplayName(ConstructionDataContextResources.Construction_Ds);
						builder.Property(x => x.BusinessFeature).DisplayName(ConstructionDataContextResources.Construction_BusinessFeature);
						builder.Property(x => x.ConstructionValue).DisplayName(ConstructionDataContextResources.Construction_ConstructionValue);
						builder.Property(x => x.File).DisplayName(ConstructionDataContextResources.Construction_File);
			        }
		        public static void BuildMetadata(MetadataBuilder<ConstructionValue> builder) {
			builder.DisplayName(ConstructionDataContextResources.ConstructionValue);
						builder.Property(x => x.Id).DisplayName(ConstructionDataContextResources.ConstructionValue_Id);
						builder.Property(x => x.Name).DisplayName(ConstructionDataContextResources.ConstructionValue_Name);
						builder.Property(x => x.DesignRequirement).DisplayName(ConstructionDataContextResources.ConstructionValue_DesignRequirement);
						builder.Property(x => x.Jgkhsj).DisplayName(ConstructionDataContextResources.ConstructionValue_Jgkhsj);
						builder.Property(x => x.Wqkhsj).DisplayName(ConstructionDataContextResources.ConstructionValue_Wqkhsj);
						builder.Property(x => x.Wdkhsj).DisplayName(ConstructionDataContextResources.ConstructionValue_Wdkhsj);
						builder.Property(x => x.Nqkhsj).DisplayName(ConstructionDataContextResources.ConstructionValue_Nqkhsj);
						builder.Property(x => x.Pjkhnl).DisplayName(ConstructionDataContextResources.ConstructionValue_Pjkhnl);
						builder.Property(x => x.Jgkhyz).DisplayName(ConstructionDataContextResources.ConstructionValue_Jgkhyz);
						builder.Property(x => x.Jzkhyz).DisplayName(ConstructionDataContextResources.ConstructionValue_Jzkhyz);
						builder.Property(x => x.File).DisplayName(ConstructionDataContextResources.ConstructionValue_File);
			        }
		        public static void BuildMetadata(MetadataBuilder<CellMapping> builder) {
			builder.DisplayName(ConstructionDataContextResources.CellMapping);
						builder.Property(x => x.Id).DisplayName(ConstructionDataContextResources.CellMapping_Id);
						builder.Property(x => x.ColumnNumber).DisplayName(ConstructionDataContextResources.CellMapping_ColumnNumber);
						builder.Property(x => x.ColumnExcelNumber).DisplayName(ConstructionDataContextResources.CellMapping_ColumnExcelNumber);
						builder.Property(x => x.ColumnName).DisplayName(ConstructionDataContextResources.CellMapping_ColumnName);
						builder.Property(x => x.Group).DisplayName(ConstructionDataContextResources.CellMapping_Group);
						builder.Property(x => x.Formula).DisplayName(ConstructionDataContextResources.CellMapping_Formula);
						builder.Property(x => x.Digital).DisplayName(ConstructionDataContextResources.CellMapping_Digital);
						builder.Property(x => x.File).DisplayName(ConstructionDataContextResources.CellMapping_File);
			        }
		        public static void BuildMetadata(MetadataBuilder<RiskLevel> builder) {
			builder.DisplayName(ConstructionDataContextResources.RiskLevel);
						builder.Property(x => x.Id).DisplayName(ConstructionDataContextResources.RiskLevel_Id);
						builder.Property(x => x.MinValue).DisplayName(ConstructionDataContextResources.RiskLevel_MinValue);
						builder.Property(x => x.MaxValue).DisplayName(ConstructionDataContextResources.RiskLevel_MaxValue);
						builder.Property(x => x.Color).DisplayName(ConstructionDataContextResources.RiskLevel_Color);
						builder.Property(x => x.Description).DisplayName(ConstructionDataContextResources.RiskLevel_Description);
						builder.Property(x => x.File).DisplayName(ConstructionDataContextResources.RiskLevel_File);
			        }
		    }
}