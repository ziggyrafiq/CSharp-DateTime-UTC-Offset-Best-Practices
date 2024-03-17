using NodaTime;

Console.WriteLine("========================================================================================\n");
/*Use UTC as the Internal Representation
Store and manipulate UTC time*/
DateTime utcNow = DateTime.UtcNow;
Console.WriteLine($"Use UTC as the Internal Representation Code Example Excuted {utcNow}");
Console.WriteLine("========================================================================================\n");


/*Store Offset Information Separately
Store DateTime and offset information separately*/
DateTime dateTime = DateTime.UtcNow;
TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(dateTime);
Console.WriteLine($"Store Offset Information Separately Code Example Excuted {offset}");
Console.WriteLine("========================================================================================\n");

// Later, when displaying the time for the user
DateTime userLocalTime = dateTime + offset;
Console.WriteLine($"Later, when displaying the time for the user Code Example Excuted {userLocalTime}");
Console.WriteLine("========================================================================================\n");

/*Use DateTimeOffset for Ambiguous Situations
Create a DateTimeOffset instance with local time and offset*/
DateTimeOffset localTime = new DateTimeOffset(DateTime.Now);
Console.WriteLine($"Use DateTimeOffset for Ambiguous Situations.  Create a DateTimeOffset instance with local time and offset.\n Code Example Excuted {localTime}");

// Convert to UTC if necessary
DateTimeOffset utcTime = localTime.ToUniversalTime();
Console.WriteLine($"Use DateTimeOffset for Ambiguous Situations.  Convert to UTC if necessary.\n Code Example Excuted {utcTime}");
Console.WriteLine("========================================================================================\n");

/*Utilise TimeZoneInfo for Accurate Conversions
Convert between time zones using TimeZoneInfo*/
TimeZoneInfo sourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

DateTime sourceTime = DateTime.UtcNow;
DateTime sourceTimeInSourceZone = TimeZoneInfo.ConvertTime(sourceTime, TimeZoneInfo.Utc, sourceTimeZone);
DateTime targetTime = TimeZoneInfo.ConvertTime(sourceTimeInSourceZone, sourceTimeZone, targetTimeZone);
Console.WriteLine($"Utilise TimeZoneInfo for Accurate Conversions. Convert between time zones using TimeZoneInfo.\n Code Example Executed {targetTime}");
Console.WriteLine("========================================================================================\n");

/*Be Aware of Daylight Saving Time Changes
Account for daylight saving time changes*/
DateTime daylightSavingDateTime = new DateTime(2023, 03, 12, 1, 30, 0);
TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

bool isAmbiguous = timeZone.IsAmbiguousTime(daylightSavingDateTime); // Check if time is ambiguous
bool isInvalid = timeZone.IsInvalidTime(daylightSavingDateTime);     // Check if time is invalid due to DST transition
string status = isAmbiguous ? "Ambiguous" : isInvalid ? "Invalid" : "Valid";
Console.WriteLine($"Date Time is {status}");
Console.WriteLine("========================================================================================\n");

/*Use NodaTime for Advanced Scenarios
Example of working with NodaTime*/
Instant now = SystemClock.Instance.GetCurrentInstant();
DateTimeZone zone = DateTimeZoneProviders.Tzdb["America/New_York"];
ZonedDateTime zonedDateTime = now.InZone(zone);
Console.WriteLine($"*Use NodaTime for Advanced Scenarios.\n Example of working with NodaTime\n Code Example Excuted {zonedDateTime}");
Console.WriteLine("========================================================================================\n");
