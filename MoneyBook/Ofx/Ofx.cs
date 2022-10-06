using System.Xml.Serialization;

namespace Ofx
{
	/// <summary>
	/// Classes below define the structure of the OFX file downloaded from from the bank.
	/// </summary>

	[XmlRoot(ElementName = "STATUS")]
	public class STATUS
	{
		[XmlElement(ElementName = "CODE")]
		public string CODE { get; set; }
		[XmlElement(ElementName = "SEVERITY")]
		public string SEVERITY { get; set; }
	}

	[XmlRoot(ElementName = "FI")]
	public class FI
	{
		[XmlElement(ElementName = "ORG")]
		public string ORG { get; set; }
		[XmlElement(ElementName = "FID")]
		public string FID { get; set; }
	}

	[XmlRoot(ElementName = "SONRS")]
	public class SONRS
	{
		[XmlElement(ElementName = "STATUS")]
		public STATUS STATUS { get; set; }
		[XmlElement(ElementName = "DTSERVER")]
		public string DTSERVER { get; set; }
		[XmlElement(ElementName = "LANGUAGE")]
		public string LANGUAGE { get; set; }
		[XmlElement(ElementName = "FI")]
		public FI FI { get; set; }
		[XmlElement(ElementName = "INTU.USERID")]
		public string INTU_USERID { get; set; }
		[XmlElement(ElementName = "INTU.BID")]
		public string INTU_BID { get; set; }
	}

	[XmlRoot(ElementName = "SIGNONMSGSRSV1")]
	public class SIGNONMSGSRSV1
	{
		[XmlElement(ElementName = "SONRS")]
		public SONRS SONRS { get; set; }
	}

	[XmlRoot(ElementName = "BANKACCTFROM")]
	public class BANKACCTFROM
	{
		[XmlElement(ElementName = "BANKID")]
		public string BANKID { get; set; }
		[XmlElement(ElementName = "ACCTID")]
		public string ACCTID { get; set; }
		[XmlElement(ElementName = "ACCTTYPE")]
		public string ACCTTYPE { get; set; }
	}

	[XmlRoot(ElementName = "STMTTRN")]
	public class STMTTRN
	{
		[XmlElement(ElementName = "TRNTYPE")]
		public string TRNTYPE { get; set; }
		[XmlElement(ElementName = "DTPOSTED")]
		public string DTPOSTED { get; set; }
		[XmlElement(ElementName = "DTAVAIL")]
		public string DTAVAIL { get; set; }
		[XmlElement(ElementName = "TRNAMT")]
		public string TRNAMT { get; set; }
		[XmlElement(ElementName = "FITID")]
		public string FITID { get; set; }
		[XmlElement(ElementName = "MEMO")]
		public string MEMO { get; set; }
	}

	[XmlRoot(ElementName = "BANKTRANLIST")]
	public class BANKTRANLIST
	{
		[XmlElement(ElementName = "DTSTART")]
		public string DTSTART { get; set; }
		[XmlElement(ElementName = "DTEND")]
		public string DTEND { get; set; }
		[XmlElement(ElementName = "STMTTRN")]
		public List<STMTTRN> STMTTRN { get; set; }
	}

	[XmlRoot(ElementName = "LEDGERBAL")]
	public class LEDGERBAL
	{
		[XmlElement(ElementName = "BALAMT")]
		public string BALAMT { get; set; }
		[XmlElement(ElementName = "DTASOF")]
		public string DTASOF { get; set; }
	}

	[XmlRoot(ElementName = "AVAILBAL")]
	public class AVAILBAL
	{
		[XmlElement(ElementName = "BALAMT")]
		public string BALAMT { get; set; }
		[XmlElement(ElementName = "DTASOF")]
		public string DTASOF { get; set; }
	}

	[XmlRoot(ElementName = "STMTRS")]
	public class STMTRS
	{
		[XmlElement(ElementName = "CURDEF")]
		public string CURDEF { get; set; }
		[XmlElement(ElementName = "BANKACCTFROM")]
		public BANKACCTFROM BANKACCTFROM { get; set; }
		[XmlElement(ElementName = "BANKTRANLIST")]
		public BANKTRANLIST BANKTRANLIST { get; set; }
		[XmlElement(ElementName = "LEDGERBAL")]
		public LEDGERBAL LEDGERBAL { get; set; }
		[XmlElement(ElementName = "AVAILBAL")]
		public AVAILBAL AVAILBAL { get; set; }
	}

	[XmlRoot(ElementName = "STMTTRNRS")]
	public class STMTTRNRS
	{
		[XmlElement(ElementName = "TRNUID")]
		public string TRNUID { get; set; }
		[XmlElement(ElementName = "STATUS")]
		public STATUS STATUS { get; set; }
		[XmlElement(ElementName = "STMTRS")]
		public STMTRS STMTRS { get; set; }
	}

	[XmlRoot(ElementName = "BANKMSGSRSV1")]
	public class BANKMSGSRSV1
	{
		[XmlElement(ElementName = "STMTTRNRS")]
		public STMTTRNRS STMTTRNRS { get; set; }
	}

	// The XmlTypeAttribute.Namespace below must be initialized to something if it is also initialized on the derived type.
	// However, the actual value does not need to be the same as the child's namespace, so modify to be something more appropriate
	// based on additional XML samples.
	[XmlType("OFX", Namespace = "")]
	[XmlInclude(typeof(OFX))]
	[XmlRoot(ElementName = "OFX", Namespace = "http://ofx.net/types/2003/04")]
	public class OFX
	{
		[XmlElement(ElementName = "SIGNONMSGSRSV1")]
		public SIGNONMSGSRSV1 SIGNONMSGSRSV1 { get; set; }
		[XmlElement(ElementName = "BANKMSGSRSV1")]
		public BANKMSGSRSV1 BANKMSGSRSV1 { get; set; }
        [XmlAttribute(AttributeName = "ofx", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ofx { get; set; }
    }
}
