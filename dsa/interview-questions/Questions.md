# Interview Question 2023
1. **Decode String**: Given a cryptic string where each word is shifted 13 chars to the right. A -> N, B -> O etc. Given a encoded string , please decode it. 

# Interview Question 2022
1. **Minimum Rooms**: Given an array of time intervals (start, end) for classroom lectures (possibly overlapping), find the minimum number of rooms required.
For example, given [(30, 75), (0, 50), (60, 150)], you should return 2.
Meeting One, starts at 30 and ends 75
0 -----|------------|------------
30 75

Meeting Two, starts at 0 and ends 50
|---------|--------------------
0 50

Meeting Three, starts at 60 and ends 150
------------|------------------|
60 150

-----|------------|------------
|---------|--------------------
------------|------------------|

```csharp
int overlaps;
Int numberOfMeetings = meetings.Count;
Foreach (meeting in Meetings)
{
for(int i = 1; i < numberOfMeetings; i++){
If (meeting[i].startTime < meeting[i+1].endTime) || (meeting[i+1].startTime < meeting[i].endTime) {
overlaps++;
}
}
}
Int numberOfRooms = overlaps + 1;
```

2. **Unique Email Address**
Every email consists of a local name and a domain name, separated by the @ sign.
For example, in alex@bottomline.com, alex is the local name, and bottomline.com is the domain name.
Besides lowercase letters, these emails may contain '.'s or '+'s.

If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name. For example, "alex.z@bottomline.com" and "alexz@bottomline.com" forward to the same email address. (Note that this rule does not apply for domain names.)

If you add a plus ('+') in the local name, everything after the first plus sign will be ignored. This allows certain emails to be filtered, for example m.y+name@email.com will be forwarded to my@email.com. (Again, this rule does not apply for domain names.)

It is possible to use both of these rules at the same time.
Given a list of emails, we send one email to each address in the list. How many different addresses actually receive mails?

Example 1:
Input: ["test.email+alex@bottomline.com","test.e.mail+bob.cathy@bottomline.com","testemail+david@bottom.line.com"]
Output: 2
Explanation: "testemail@bottomline.com" and "testemail@bottom.line.com" actually receive mails

Note:
1 <= emails[i].length <= 100
1 <= emails.length <= 100
Each emails[i] contains exactly one '@' character.
All local and domain names are non-empty.
Local names do not start with a '+' character.