namespace Test
{
    using Spire.Xls;

    public class TestFreeSpire
    {
        public static byte[] FromXls()
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile("Book1.xlsx");
            Worksheet sheet = workbook.Worksheets[0];
            using var stream = sheet.ToImage(1, 1, 2, 3);
            using var ms = new MemoryStream();
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms.ToArray();
        }
    }
}
