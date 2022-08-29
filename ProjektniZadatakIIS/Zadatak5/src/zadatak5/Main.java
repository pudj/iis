/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package zadatak5;


import java.io.IOException;
import org.apache.xmlrpc.XmlRpcException;
import org.apache.xmlrpc.server.PropertyHandlerMapping;
import org.apache.xmlrpc.server.XmlRpcServer;
import org.apache.xmlrpc.server.XmlRpcServerConfigImpl;
import org.apache.xmlrpc.webserver.WebServer;

/**
 *
 * @author nadan.marenkovic
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    
    //http://localhost:8081/weather
    
    //<?xml version="1.0" encoding="ISO-8859-1"?>
    //<methodCall>
    //<methodName>weather.getweatherbycity</methodName>
     //<params>
        //<param>
            //<value><string>Sisak</string></value>
        //</param>
     //</params>
    //</methodCall>
    
    public static void main(String[] args) throws XmlRpcException, IOException {
        WebServer webServer = new WebServer(8081);
        XmlRpcServer xmlRpcServer = webServer.getXmlRpcServer();
        
        PropertyHandlerMapping phm = new PropertyHandlerMapping();
        phm.addHandler("weather", WeatherServer.class);
        xmlRpcServer.setHandlerMapping(phm);
        
        XmlRpcServerConfigImpl serverConfig =
            (XmlRpcServerConfigImpl) xmlRpcServer.getConfig();
        serverConfig.setEnabledForExtensions(true);
        serverConfig.setContentLengthOptional(false);
        
        webServer.start();
        
        System.out.println("Started web server...");
        
    }
    
}
