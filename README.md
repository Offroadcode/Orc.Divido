# Orc.Divido
A .Net client for the Divido payment service, based on documentation from http://integrations.divido.com

## Example usage
```C#
Orc.Divido.DividoClient client = new DividoClient("sandbox_Api.KEY");
var finances= client.Finances();
var deal = client.DealCalcualator(1234.51m, 200, "GB", "FA0ED2F22-2FE2-25E7-D129-A29359F7F529");
var offer = client.CreditRequest(200, "FA0ED2F22-2FE2-25E7-D129-A29359F7F529", "GB", "EN", 1234.51m, "TEST-01", "GBP", GetTestCustomer(), GetTestProducts(), true, "https://TEST.co.uk/response", "https://TEST.co.uk/checkout", "https://TEST.co.uk/redirect");
```            
