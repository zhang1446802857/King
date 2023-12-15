using Scriban;

namespace King.WebApi.Common.ScribanTools
{
    public class ScribanTool
    {
        public static string templateServicePath = "Service.tt";
        public static string templateRepositoryPath = "Repository.tt";
        public static string templateIServicePath = "IService.tt";
        public static string templateIRepositoryPath = "IRepository.tt";
        public static string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScribanTools\\Template");

        public static void CodeGenerationClass(string codeName, string codeModel)
        {
            CodeFile(codeName, codeModel, "..\\King.WebApi.Service\\IService\\", "I{0}Service.cs", templateIServicePath);
            CodeFile(codeName, codeModel, "..\\King.WebApi.Service\\Service\\", "{0}Service.cs", templateServicePath);
            CodeFile(codeName, codeModel, "..\\King.WebApi.Repository\\IRepository\\", "I{0}Repository.cs", templateIRepositoryPath);
            CodeFile(codeName, codeModel, "..\\King.WebApi.Repository\\Repository\\", "{0}Repository.cs", templateRepositoryPath);
        }

        public static void CodeFile(string codeName, string codeModel, string outPath, string fileNameFormat, string templatePath)
        {
            var template = Template.Parse(File.ReadAllText(Path.Combine(basePath, templatePath)));
            var result = template.Render(new { name = codeName, model = codeModel });
            var fileName = string.Format(fileNameFormat, codeName);
            outPath = Path.Combine(outPath, fileName);
            File.WriteAllText(outPath, result);
        }

        public static void CodeIService(string codeName, string codeModel, string outPath)
        {
            var template = Template.Parse(File.ReadAllText(Path.Combine(basePath, templateIServicePath)));
            var result = template.Render(new { name = codeName, model = codeModel });
            outPath = Path.Combine(outPath, $"I{codeName}Service.cs");
            File.WriteAllText(outPath, result);
        }

        public static void CodeService(string codeName, string codeModel, string outPath)
        {
            var template = Template.Parse(File.ReadAllText(Path.Combine(basePath, templateServicePath)));
            var result = template.Render(new { name = codeName, model = codeModel });
            outPath = Path.Combine(outPath, $"{codeName}Service.cs");
            File.WriteAllText(outPath, result);
        }

        public static void CodeIRepository(string codeName, string codeModel, string outPath)
        {
            var template = Template.Parse(File.ReadAllText(Path.Combine(basePath, templateIRepositoryPath)));
            var result = template.Render(new { name = codeName, model = codeModel });
            outPath = Path.Combine(outPath, $"I{codeName}Repository.cs");
            File.WriteAllText(outPath, result);
        }

        public static void CodeRepository(string codeName, string codeModel, string outPath)
        {
            var template = Template.Parse(File.ReadAllText(Path.Combine(basePath, templateRepositoryPath)));
            var result = template.Render(new { name = codeName, model = codeModel });
            outPath = Path.Combine(outPath, $"{codeName}Repository.cs");
            File.WriteAllText(outPath, result);
        }
    }
}