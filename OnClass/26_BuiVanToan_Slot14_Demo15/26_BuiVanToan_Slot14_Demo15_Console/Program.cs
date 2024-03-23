
using _26_BuiVanToan_Slot14_Demo15;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;


Uri baseuri = new Uri("http://localhost:8733/Design_Time_Addresses/_26_BuiVanToan_Slot14_Demo15/CaculateService/");
ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseuri);
try
{
    // Step 3: Add a service endpoint.
    selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

    // Step 4: Enable metadata exchange.
    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
    smb.HttpGetEnabled = true;
    selfHost.Description.Behaviors.Add(smb);

    // Step 5: Start the service.
    selfHost.Open();
    Console.WriteLine("The service is ready.");

    // Close the ServiceHost to stop the service.
    Console.WriteLine("Press <Enter> to terminate the service.");
    Console.WriteLine();
    Console.ReadLine();
    selfHost.Close();
}
catch (CommunicationException ce)
{
    Console.WriteLine("An exception occurred: {0}", ce.Message);
    selfHost.Abort();
}