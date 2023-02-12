using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Imx.Sdk;
using Imx.Sdk.Gen.Api;
using Imx.Sdk.Gen.Client;
using Imx.Sdk.Gen.Model;
using System;


public class NFTManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // user registration
        //  * Generating an ImmutableX L2 user account for an Ethereum L1 account
        //  * Registering the L1 <-> L2 wallet pair
        // By default, Immutable's registerUser endpoint first registers a user off-chain.
        try
        {
            Client client = new Client(new Config()
            {
                Environment = EnvironmentSelector.Sandbox // Or EnvironmentSelector.Sandbox
            });


            Configuration config = new Configuration();
            config.BasePath = "https://api.sandbox.x.immutable.com/";
            var apiInstance = new CollectionsApi(config);
            var address = "0x827c0c0a3d47260ba6984ee05d70227a81c79ae7";  // string | Collection contract address


            // Get details of a collection at the given address
            Collection result = apiInstance.GetCollection(address);
            print(result);




            print("before");

            print("after");
        }
        catch (Exception e)
        {
            print("Error message: " + e.Message);
            print(e.StackTrace);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}