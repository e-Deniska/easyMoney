using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Data;
using System.Drawing;
using easyMoney.Controls;
using easyMoney.Utilities;

namespace easyMoney.Manager
{
    class FormHelper
    {
        /// <summary>
        /// Add template to a specific list
        /// </summary>
        /// <param name="collection">List, where to add template</param>
        /// <param name="template">Template to add</param>
        /// <param name="onClick">Click handlers</param>
        public static void InsertTemplate(ToolStripItemCollection collection, MoneyDataSet.TransactionTemplatesRow template, EventHandler onClick)
        {
            Image image = null;
            if (template.ID.Equals(MoneyDataSet.IDs.TransactionTemplates.Transfer))
            {
                image = Properties.Resources.table_relationship;
            }
            ToolStripMenuItem tsmiFromTemplate = new ToolStripMenuItem(template.Title, image, onClick);
            tsmiFromTemplate.Tag = template;
            tsmiFromTemplate.ToolTipText = template.Message;

            collection.Add(tsmiFromTemplate);
        }

        /// <summary>
        /// Shows introduction dialog
        /// </summary>
        public static void ShowIntroduction(Form parernt)
        {
            try
            {
                List<IntroductionForm.Page> wizardPages = new List<IntroductionForm.Page>();
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.WelcomeTitle, Resources.Introduction.WelcomeText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.AccountsTitle, Resources.Introduction.AccountsText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.TransactionsTitle, Resources.Introduction.TransactionsText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.PlansTitle, Resources.Introduction.PlansText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.TagsTitle, Resources.Introduction.TagsText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.ReportsTitle, Resources.Introduction.ReportsText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.NextStepsTitle, Resources.Introduction.NextStepsText));

                IntroductionForm wizard = new IntroductionForm(wizardPages);
                wizard.Icon = parernt.Icon;
                wizard.Text = Resources.Introduction.WelcomeTitle;
                wizard.ShowDialog(parernt);
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.ErrorShowingIntroduction, e);
            }
        }

        public static bool DeleteTransaction(MoneyDataSet.TransactionsRow transaction)
        {
            String message = transaction.IsPairReferenceIDNull() ? String.Format(Resources.Labels.DeleteTransactionFormat, transaction.FullTitle) :
                String.Format(Resources.Labels.DeletePairedTransactionFormat, transaction.FullTitle);

            if (MessageBox.Show(message, Resources.Labels.DeleteTransactionTitle, MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                MoneyDataKeeper.Instance.DeleteTransaction(transaction.ID);
                return true;
            }
            return false;
        }

        public static bool DeletePlannedTransaction(MoneyDataSet.PlannedTransactionsRow plan)
        {
            String message = plan.IsPairReferenceIDNull() ? String.Format(Resources.Labels.DeletePlannedTransactionFormat, plan.FullTitle) :
                String.Format(Resources.Labels.DeletePairedPlannedTransactionFormat, plan.FullTitle);

            if (MessageBox.Show(message, Resources.Labels.DeletePlannedTransactionTitle, MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                MoneyDataKeeper.Instance.DeletePlannedTransaction(plan.ID);
                return true;
            }
            return false;
        }

        public static bool DeleteAccount(MoneyDataSet.AccountsRow account)
        {
            if (MessageBox.Show(String.Format(Resources.Labels.DeleteAccountFormat, account.Title),
                Resources.Labels.DeleteAccountTitle, MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                MoneyDataKeeper.Instance.DeleteAccount(account.ID);
                return true;
            }
            return false;
        }        
    }
}
