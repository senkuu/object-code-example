using System;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace NIRScore.excel
{

  public class ExcelManager
  {

    private IWorkbook workbook;
    private ISheet sheet;
    private readonly int offset;

    public ExcelManager(int offset)
    {
      this.offset = offset;
    }

    public ExcelManager(string fileName)
    {
      offset = 0;
      Open(fileName);
    }

    public ExcelManager(string fileName, int offset)
    {
      this.offset = offset;
      Open(fileName);
    }

    public bool Open(string fileName)
    {
      try
      {
        //
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        if (fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0)
        {
          workbook = new XSSFWorkbook(fs);
        }
        else if (fileName.IndexOf(".xls", StringComparison.Ordinal) > 0)
        {
          workbook = new HSSFWorkbook(fs);
        }

        sheet = workbook.GetSheetAt(0);
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }
      return true;

    }

    public int MaxRow
    {
      get
      {
        return sheet.LastRowNum + 1;
      }
    }

    public int DataSize
    {
      get
      {
        return MaxRow - offset;
      }
    }



    public IRow GetRow(int number)
    {
      return sheet.GetRow(number + offset);
    }

    public IRow GetRowAbsolute(int number)
    {
      return sheet.GetRow(number);
    }

    public ICell GetCell(int col, int row)
    {
      return GetRow(row).GetCell(col);
    }

    public ICell GetCellAbsolute(int col, int row)
    {
      IRow lrow = GetRowAbsolute(row);
      if (lrow == null)
      {
        return null;
      }
      return lrow.GetCell(col);
    }

    public bool IsNullCellAbsolute(int col, int row)
    {
      ICell cell = GetCellAbsolute(col, row);
      if (cell == null)
      {
        return true;
      }
      return false;
    }

    public bool IsNumericCell(ICell cell){
      return cell.CellType == CellType.Numeric;
    }

    public bool IsStringCell(ICell cell){
      return cell.CellType == CellType.String;
    }

    public bool IsNumericCellAbsolute(int col, int row)
    {
      ICell cell = GetCellAbsolute(col, row);
      return IsNumericCell(cell);
    }

    public bool IsStringCellAbsolute(int col, int row)
    {
      ICell cell = GetCellAbsolute(col, row);
      return IsStringCell(cell);
    }

    public bool TestCellAbsolute(int col, int row, double value)
    {
      if (IsNullCellAbsolute(col, row))
      {
        return false;
      }

      if (!IsNumericCellAbsolute(col, row)){
        return false;
      }

      double cellvalue = NumericCellValueAbsolute(col, row);
      return cellvalue == value;
    }

    public bool TestCellAbsolute(int col, int row, string value)
    {
      if (IsNullCellAbsolute(col, row))
      {
        return false;
      }

      if (!IsStringCellAbsolute(col, row)){
        return false;
      }

      string cellvalue = StringCellValueAbsolute(col, row);
      return cellvalue.Equals(value);
    }

    public double NumericCellValue(int col, int row)
    {
      return GetCell(col, row).NumericCellValue;
    }

    public double NumericCellValueAbsolute(int col, int row)
    {
      return GetCellAbsolute(col, row).NumericCellValue;
    }

    public string StringCellValue(int col, int row)
    {
      ICell cell = GetCell(col, row);
      if (cell != null)
      {
        return cell.StringCellValue;
      }
      return "";
    }

    public string StringCellValueAbsolute(int col, int row)
    {
      ICell cell = GetCellAbsolute(col, row);
      if (cell != null)
      {
        return cell.StringCellValue;
      }
      return "";
    }

    public bool TryCellValueAsNumeric(ICell cell, out double value, double dvalue=Double.NaN){
      if (IsNumericCell(cell)){
        value = cell.NumericCellValue;
        return true;
      }
      else if (IsStringCell(cell)){
        string svalue = cell.StringCellValue;
        try {
          value = double.Parse(svalue, System.Globalization.CultureInfo.InvariantCulture);
          return true;
        }
        catch {
          value = dvalue;
          return false;
        }
      }
      value = dvalue;
      return false;
    }

    public bool TryCellValueAsNumericAbsolute(int col, int row, out double value){
      return TryCellValueAsNumeric(GetCellAbsolute(col, row), out value);
    }

    public bool TryCellValueAsNumeric(int col, int row, out double value){
      return TryCellValueAsNumeric(GetCell(col, row), out value);
    }
  }
}
