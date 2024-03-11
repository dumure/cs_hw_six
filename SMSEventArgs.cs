internal class SMSEventArgs : EventArgs
{
	private string sms;
	public string SMS
	{
		get { return sms; }
		set 
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (value.Length <= 160)
				{
					sms = value;
				}
				else
				{
                    throw new ArgumentException("Bad argument");
                }
			}
			else
			{
                throw new ArgumentException("Bad argument");
            }
		}
	}
}