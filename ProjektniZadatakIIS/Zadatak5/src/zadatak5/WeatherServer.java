/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package zadatak5;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

/**
 *
 * @author nadan.marenkovic
 */
public class WeatherServer {
    
    final String USER_AGENT = "Mozilla/5.0";
    final String CONTENT_LENGTH = "131";
    StringBuffer response = new StringBuffer();
    String url = "https://vrijeme.hr/hrvatska_n.xml";
    
    public String getweatherbycity(String city) throws IOException, MalformedURLException, SAXException, ParserConfigurationException, SAXException, SAXException {
        System.out.print(city);
        return GetXml(city);
        
        
    }
    
    private String GetXml(String city) throws MalformedURLException, IOException, SAXException, ParserConfigurationException {
        String temperature = "";
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        DocumentBuilder db = dbf.newDocumentBuilder();
        Document doc = db.parse(new URL(url).openStream());
                
        Element root = doc.getDocumentElement();
        
        NodeList nList = doc.getElementsByTagName("Grad");
        for(int temp = 0; temp < nList.getLength(); temp++) {
            Node node = nList.item(temp);
            if(node.getNodeType() == Node.ELEMENT_NODE) {
                Element eElement = (Element) node;
                String cityName = eElement.getElementsByTagName("GradIme").item(0).getTextContent();
                System.out.println(cityName);
                if(cityName.equals(city)) {
                    Node tempNode = doc.getElementsByTagName("Temp").item(temp);
                    temperature = tempNode.getTextContent();
                    //temperature = eElement.getElementsByTagName("Temp").item(temp).getTextContent();
                    return temperature;
                }
            }
        }
        return "No city with that name!";
    }
}
