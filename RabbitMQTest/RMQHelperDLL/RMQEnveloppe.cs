using System.Data;
using System.Text;
using System.Text.Json;

namespace RMQHelperDLL
{
    /// <summary>
    /// Represents a message envelope for RabbitMQ, encapsulating message metadata, message content, and optional
    /// XML-serialized data. Provides methods for XML data handling and JSON-based serialization and deserialization.
    /// </summary>
    /// <remarks>Use this class to package messages for transmission via RabbitMQ, including structured data
    /// as XML when needed. The envelope supports serializing its contents to a JSON byte array for transport and
    /// reconstructing itself from such a payload. The XML data can be set or retrieved as a DataSet, and is stored as a
    /// string in the envelope. If no XML data is set, the XmlData property returns an empty string.</remarks>
    public class RMQEnveloppe
    {
        string _xmlData;

        /// <summary>
        /// Initializes a new instance of the RMQEnveloppe class with the specified message name, sender, message text,
        /// and associated XML data.
        /// </summary>
        /// <param name="messageName">The name that identifies the type or purpose of the message.</param>
        /// <param name="sender">The identifier of the sender, representing the origin of the message.</param>
        /// <param name="messageText">The main textual content of the message.</param>
        /// <param name="xmlData">The XML-formatted data associated with the message, providing additional structured information.</param>
        public RMQEnveloppe(string messageName, string sender, string messageText, string xmlData)
        {
            MessageName = messageName;
            Sender = sender;
            MessageText = messageText;
            _xmlData = xmlData;
        }

        public string MessageName { get; set; }
        public string Sender { get; set; }
        public string MessageText { get; set;  }

        /// <summary>
        /// Sets the internal data representation using the specified DataSet, or clears the data if the DataSet is
        /// null.
        /// </summary>
        /// <remarks>This method serializes the provided DataSet to an XML string, including its schema,
        /// for storage or further processing. If the DataSet is null, the internal data is set to an empty
        /// string.</remarks>
        /// <param name="ds">The DataSet to serialize to XML format. If null, the internal data is cleared.</param>
        public void SetData(DataSet? ds)
        {
            if (ds == null)
            {
                _xmlData = string.Empty;
            }
            else
            {
                using (var sw = new System.IO.StringWriter())
                {
                    ds.WriteXml(sw, System.Data.XmlWriteMode.WriteSchema); 
                    _xmlData = sw.ToString();
                }
            }
        }

        /// <summary>
        /// Retrieves a DataSet containing the data represented by the current XML string.
        /// </summary>
        /// <remarks>The method reads XML data from the internal string and attempts to parse it into a
        /// DataSet using schema information if available. Ensure that the XML string is well-formed and valid for
        /// DataSet parsing to avoid exceptions. The returned DataSet reflects the structure and data defined in the
        /// XML.</remarks>
        /// <returns>A DataSet populated with data from the XML string if the data is not null or empty; otherwise, null.</returns>
        public DataSet GetData()
        {
            if (_xmlData != null && _xmlData != string.Empty)
            {
                DataSet ds = new DataSet();

                using (var sr = new System.IO.StringReader(_xmlData))
                {
                    ds.ReadXml(sr, XmlReadMode.ReadSchema);
                    // You can then save xmlString to a file or send it over a network
                }

                return ds;
            }
            else
            {
                return null;
            }
        }

        public string XmlData { get { return _xmlData; } }


        #region "Envoie et reception de messages"
        /// <summary>
        /// Serializes the current object to a JSON-formatted byte array using UTF-8 encoding.
        /// </summary>
        /// <remarks>This method uses System.Text.Json.JsonSerializer to convert the object to JSON. The
        /// object must be serializable and should not contain circular references, as this may result in a
        /// serialization exception.</remarks>
        /// <returns>A byte array containing the UTF-8 encoded JSON representation of the current object.</returns>
        public byte[] Serialise()
        { 
            string json = System.Text.Json.JsonSerializer.Serialize(this);
            byte[] body = Encoding.UTF8.GetBytes(json);
            return body;
        }

        /// <summary>
        /// Deserializes a byte array containing a JSON representation of an RMQEnveloppe object.
        /// </summary>
        /// <remarks>If an error occurs during deserialization, the method returns an RMQEnveloppe
        /// instance with the MessageText property set to an error description. The method uses UTF-8 encoding and
        /// System.Text.Json for deserialization.</remarks>
        /// <param name="body">The byte array that contains the UTF-8 encoded JSON data to deserialize.</param>
        /// <returns>An instance of RMQEnveloppe populated with the data from the JSON. If deserialization fails, the returned
        /// object's MessageText property contains an error message.</returns>
        public static RMQEnveloppe Deserialise(byte[] body)
        {
            RMQEnveloppe message1 = new RMQEnveloppe("","", "", null);

            try
            {
                string json = Encoding.UTF8.GetString(body);
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };
                message1 = System.Text.Json.JsonSerializer.Deserialize<RMQEnveloppe>(json,options);

            }
            catch (Exception ex) {
                message1.MessageText = "Error deserialising message: " + ex.Message;
            }

            return message1;
        }
        #endregion
    }
}
