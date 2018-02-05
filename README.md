# PayWithMPGS (Mastercard Payment Gateway Services)


You can add your Merchant ID(Merchant ID) and API Password in the Web.Config File and you are good to go.<br/>
Below is the sample of the Configs.
```
    <add key="Debug" value="True" />
    <add key="UseProxy" value="False" />
    <add key="ProxyHost" value="" />
    <add key="ProxyUser" value="" />
    <add key="ProxyPassword" value="" />
    <add key="ProxyDomain" value="" />
    <add key="GatewayHost" value="eu-gateway.mastercard.com" />
    <add key="Version" value="34"/>
    <add key="UseSSL" value="True" />
    <add key="MerchantId" value="[MERCHANT_ID]" />
    <add key="Username" value="merchant.[MERCHANT_ID]"/>
    <add key="Password" value="[API_PASSWORD]" />
    <add key="IgnoreSslErrors" value="False" />
```
API Password you will get from the merchant dashboard, under Admin>Integration settings.<br/>
You will get 2 passwords you can use one of them.<br/>
<br/>Since the MPGS doesn't have a MVC Sample code I have Created it in MVC.<br/>
<br/>Please go throught the below link for guidelines and more sample codes.<br/>
<a href="https://ap-gateway.mastercard.com/api/documentation/integrationGuidelines/index.html?locale=en_US" target="_blank">https://ap-gateway.mastercard.com/api/documentation/integrationGuidelines/index.html?locale=en_US</a><br/>
Once you are done with developement and testing replace the config values to production.<br/>
