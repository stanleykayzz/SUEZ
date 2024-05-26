Question 1/2-C#

We have a pump that has a sensor measuring it's on/off status. The sensor stores all the values in a local database in a time series format 
Example:


- 10/01/2019 10:01:25-1
- 10/01/2019 12:41:01-0
- 10/01/2019 13:02:42-> 0
- 10/01/2019 15:25:12-1
- 10/01/2019 16:43:33 -> 0



The sensor has an API that provides the ability to retrieve all the statuses measured on the pump. We want to use this API to get all the on/off statuses and compute, on a specific period, the duration during which the pump was running (ie measured value was 1)


Write the body of the method :

GetRunningDurationOnPeriod (Measure[] onOffMeasures, DateTime start, DateTime end)

'onOffMeasures'    is a list of all measured statuses retrieved from the sensor.
'start' and 'end' are the dates between which we want to compute the duration.


Example:

If we receive these measures:

10/01/2019 10:14:11 -> 0
10/01/2019 10:55:00 -> 1
10/01/2019 12:21:00 -> 0 
10/01/2019 13:14:12 -> 1
10/01/2019 14:45:14 -> 0
And if we want to compute the running duration between 10/01/2019 11:00:00 and 10/01/2019 13:00:00, we would compute the following duration: 1 hour and 21 minutes (the pump started to run at 10:55 and stopped at 12:21)

-----------------------------------------------------------------------------------------------------------------

Question 2/2-C#            Elapsed time: 00:03/30:00


Answer


You have been asked to perform a code review on a pull request created by Pedro, a developer who recently joined the team.

Pedro was asked to develop the PumpService feature which provides information on pumps. He was given the requirements by the business analyst and he created the IPump Service interface as well as the implementation.

He was told to rely on IPumpDataProvider to get all measurements from the pump.

Have a look at his code below, and add your comments (in French or English) so Pedro can understand what is wrong with his code and what he needs to do in order to improve it (for both the interface and the implementation)

For each comment, write the number of the line and your comment. 

Example:

51->Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce tempus, ent sed lacinia ultrices, nisi eros consequat erat, ut placerat orci quam sollicitudin metus. Suspendisse condimentum molestie placerat


270> Nulla varius egestas lectus. Suspendisse potenti. Maecenas iaculis nec ex molestie fringilla. Vivamus sem quam. bibendum sed accumsan et, congue vitae magna.




50 	public interface IPumpService
51	{
52		DateTime[] GetDateTimesWhereThePumpStarted (Pump pump);
53
54		int GetNumberOfStartsSinceDate (Pump pump, DateTime date);
55
56		bool HasPumpStarted TooMuchTimes (Pump pump);
57
58		Tuple<Pump, double> GetMost Efficient Pump (List<Pump> pumps);
59
 


PumpService.cs
62	public class PumpService: IPumpService	
63	{
64		private ILogger<PumpService> logger;
65		private IPumpDataProvider pumpDataProvider;
66
67		public PumpService()	
68		{
69			this.pumpDataProvider = new PumpDataProvider();
