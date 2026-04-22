using RMQHelperDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTestBench2
{
    public class HistoryItem
    {
        public string MessageDate { get; internal set; }
        public string Direction { get; internal set; }
        public string DistantQueue { get; internal set; }
        public string MessageName { get; internal set; }
        public string FilePath { get; internal set; }
        public RMQEnveloppe Content { get; internal set; }

        public HistoryItem(RMQEnveloppe enveloppe, string direction)
        {
            MessageDate = $"{DateTime.Now:HHmmss.fff}";
            Direction = direction;
            DistantQueue = enveloppe.Sender;
            MessageName = enveloppe.MessageName;
            Content = enveloppe;
            FilePath = "";
        }

        public void Save(string archivePath)
        {
            FilePath = Path.Combine(archivePath, $"[{MessageDate}][{Direction}][{DistantQueue}][{MessageName}].txt");
            if (!File.Exists(FilePath))
            {
                System.IO.File.WriteAllBytes(FilePath, Content.Serialise());
            }

        }

        public static HistoryItem Load(string filePath)
        {
            var content = System.IO.File.ReadAllBytes(filePath);
            var enveloppe = RMQEnveloppe.Deserialise(content);
            var getFileName = Path.GetFileNameWithoutExtension(filePath);
            string[] parts = getFileName.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            var historyItem = new HistoryItem(enveloppe, parts[1]);
            historyItem.MessageDate = parts[0];
            historyItem.FilePath = filePath;
            return historyItem;
        }

        public static List<HistoryItem> LoadAll(string archivePath)
        {
            var files = Directory.GetFiles(archivePath, "*.txt");
            List<HistoryItem> historyItems = new List<HistoryItem>();
            foreach (var file in files)
            {
                historyItems.Add(Load(file));
            }
            return historyItems;
        }
    }
}
