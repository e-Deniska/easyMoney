using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using easyMoney.Utilities;

namespace easyMoney.Data
{

    public class MoneyDataImporter
    {

        #region Additional classes

        private enum ImportFileType
        {
            Unknown,
            Xml,
            Csv,
            Txt
        }

        public class ImportedRecord
        {
            public DateTime Date { get; private set; }
            public MoneyDataSet.TransactionTemplatesRow Template { get; private set; }
            public String Title { get; private set; }
            public Double Amount { get; private set; }
            public MoneyDataSet.AccountTypesRow AccountType { get; private set; }
            public String Tags { get; private set; }

            public ImportedRecord(DateTime date, MoneyDataSet.TransactionTemplatesRow template, String title, 
                Double amount, MoneyDataSet.AccountTypesRow accountType, String tags)
            {
                Date = date;
                Template = template;
                Title = title;
                Amount = amount;
                AccountType = accountType;
                Tags = tags;
            }

            public override string ToString()
            {
                return String.Format(Consts.UI.ImportedTransactionsListFormat, String.Empty, Date, Title);
            }
        }

        #endregion

        #region Class constants

        public const String FILE_XML = ".XML";
        public const String FILE_CSV = ".CSV";
        public const String FILE_TXT = ".TXT";
        public static readonly String[] FILE_SEPARATORS = { "|", ",", "\t" };
        
        #endregion

        #region Class members

        private ImportFileType fileType = ImportFileType.Unknown;
        private ImportDataSet ds = new ImportDataSet();
        private String fileName = null;
        private MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
        
        #endregion

        #region Class properties

        public List<ImportedRecord> Records { get; private set; }

        #endregion

        #region File parsing/processing

        public MoneyDataImporter(String fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                throw new FileNotFoundException("Import file not found", fileName);
            }

            this.fileName = fileName;

            switch (fi.Extension.ToUpper())
            {
                case FILE_CSV:
                    fileType = ImportFileType.Csv;
                    break;

                case FILE_XML:
                    fileType = ImportFileType.Xml;
                    break;

                case FILE_TXT:
                    fileType = ImportFileType.Txt;
                    break;

                default:
                    throw new FormatException("Import file is in invalid format");
            }

            parseFile();
            processRecords();
        }

        private void parseFile()
        {
            switch (fileType)
            {
                case ImportFileType.Csv:
                case ImportFileType.Txt:
                    parseFileTxt();
                    break;

                case ImportFileType.Xml:
                    parseFileXml();
                    break;

                default:
                    throw new FormatException("Import file is in invalid format");
            }
        }

        private void parseFileTxt()
        {
            int positionDelta = (fileType == ImportFileType.Txt) ? 1 : 0;

            String[] lines = File.ReadAllLines(fileName);
            foreach (String line in lines)
            {
                String[] fields = line.Split(FILE_SEPARATORS, StringSplitOptions.None);
                ImportDataSet.TransactionsRow transaction = ds.Transactions.NewTransactionsRow();
                DateTime date;
                if (DateTime.TryParse(fields[0 + positionDelta], out date))
                {
                    transaction.Date = date;
                }
                transaction.Template = fields[1 + positionDelta].Trim();
                transaction.Title = fields[2 + positionDelta].Trim();
                Double amount = 0;
                if (Double.TryParse(fields[3 + positionDelta], out amount))
                {
                    transaction.Amount = amount;
                }
                transaction.AccountType = fields[4 + positionDelta].Trim();
                transaction.Tags = fields[5 + positionDelta].Trim();
            
                ds.Transactions.AddTransactionsRow(transaction);
            }
            ds.AcceptChanges();
        }

        private void parseFileXml()
        {
            ds.ReadXml(fileName);
        }

        private MoneyDataSet.TransactionTemplatesRow matchTemplate(String sourceType)
        {
            if (sourceType == null) return null;

            return keeper.DataSet.TransactionTemplates.Where(t => (t.ID.Equals(sourceType.Trim().ToUpper()))).SingleOrDefault();
        }


        private MoneyDataSet.AccountTypesRow matchAccountType(String sourceType)
        {
            if (sourceType == null) return null;

            return keeper.DataSet.AccountTypes.Where(t => (t.ID.Equals(sourceType.Trim().ToUpper()))).SingleOrDefault();
        }

        private void processRecords()
        {
            List<ImportedRecord> list = new List<ImportedRecord>();

            foreach (ImportDataSet.TransactionsRow transaction in ds.Transactions)
            {
                if (transaction.IsDateNull())
                {
                    transaction.Date = DateTime.Now;
                }

                if (transaction.IsAmountNull())
                {
                    transaction.Amount = 0;
                }

                transaction.Title = transaction.Title == null ? String.Empty : transaction.Title.Trim();
                transaction.Tags = transaction.Tags == null ? String.Empty : transaction.Tags.Trim();

                list.Add(new ImportedRecord(transaction.Date, matchTemplate(transaction.Template), transaction.Title, 
                    transaction.Amount, matchAccountType(transaction.AccountType), transaction.Tags));
            }

            ds.Clear();
            ds.AcceptChanges();

            this.Records = list;
        }

        #endregion
        
    }
}
