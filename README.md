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

