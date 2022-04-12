using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class request : MonoBehaviour
{
    public Text a1; 
    public Text a2; 
    public Text a3; 
    public Text a4; 
    public Text a5; 
    public Text a6; 
    void Start()
    {
    

    //    StartCoroutine(GetRequestUser("http://localhost:8242/api/Users1/1"));
    StartCoroutine(GetRequest("http://localhost:8242/api/Players"));
   // StartCoroutine(GetRequest1("http://localhost:8242/api/Players"));
        //    StartCoroutine(GetRequestRanks("http://localhost:8242/api/Ranks1"));
      //  StartCoroutine(GetRequestPlayerSkin("http://localhost:8242/api/PlayerSkins1/1"));
      
      //  StartCoroutine(GetRequestSkin("http://localhost:8242/api/Skins1/1"));
    }
    //player
    //IEnumerator GetRequest1(string url)
    //{
    //    using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
    //    {
    //        yield return webRequest.SendWebRequest();
    //        switch (webRequest.result)
    //        {
    //            case UnityWebRequest.Result.ConnectionError:
    //            case UnityWebRequest.Result.DataProcessingError:
    //            case UnityWebRequest.Result.ProtocolError:
    //                print("error");
    //                break;
    //            case UnityWebRequest.Result.Success:

    //                //    print(webRequest.downloadHandler.text);
    //                print("Players");
    //                Player player = JsonUtility.FromJson<Player>(webRequest.downloadHandler.text);

    //                print("Nickname: " + player.nickName);
    //                print("datos : " + player.IdNavigation);


    //                break;
    //        }
    //    }
    //}
    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    print("error");
                    break;
                case UnityWebRequest.Result.Success:
                  
              //print(webRequest.downloadHandler.text);
                   // print("Players");
                    Players players = JsonUtility.FromJson<Players>("{\"players\":"+webRequest.downloadHandler.text+"}");

                    //  print("Nickname: "+players);
                    //print("datos : "+players.IdNavigation);

                    DateTime NowTime = DateTime.Now;
                    // a1.text= players.reg

                    for (int i = 0; i < players.players.Length; i++)
                    {
                        print("Players"  + players.players[i].nickName + "Max Experiencia " + players.players[0].playerSkins);

                        a1.text= (players.players[0].id+(" ")+players.players[0].nickName).ToString();
                        a2.text= (players.players[1].id+ (" ") + players.players[1].nickName).ToString();
                        a3.text= (players.players[2].id+ (" ") + players.players[2].nickName).ToString();
                        a4.text= (players.players[3].IdNavigation+ (" ") + players.players[3].nickName).ToString();
                  
                    }
                    break;
            }
        }
    }

    IEnumerator GetRequestPlayerSkin(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    print("error");
                    break;
                case UnityWebRequest.Result.Success:

                    Skins skins = JsonUtility.FromJson<Skins>("{\"players\":" + webRequest.downloadHandler.text + "}"); 
           
                   for (int i = 0; i <skins.skins.Length; i++)
                    {
                        print("Skin Name " + skins.skins[i].name);
                        //a1.text = (players.players[0].id + (" ") + players.players[0].nickName).ToString();
                        //a2.text = (players.players[1].id + (" ") + players.players[1].nickName).ToString();
                        //a3.text = (players.players[2].id + (" ") + players.players[2].nickName).ToString();

                    }
                    break;
            }
        }
    }
    ////Playerskin
    IEnumerator GetRequestPlayerSkin1(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    print("error");
                    break;
                case UnityWebRequest.Result.Success:
                    PlayerSkins playerSkins = JsonUtility.FromJson<PlayerSkins>(webRequest.downloadHandler.text);

                    print("Fecha: " + playerSkins.date);
                    print("playerid: " + playerSkins.playerId);
                    print("skinid: " + playerSkins.skinId);


                    break;
            }
        }
    }
    //ranks
    IEnumerator GetRequestRanks(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    print("error");
                    break;
                case UnityWebRequest.Result.Success:

                    // print(webRequest.downloadHandler.text);
                    print("Rank");
                    
                    Ranking ranking= JsonUtility.FromJson<Ranking>(webRequest.downloadHandler.text);

                    print("id: "+ ranking.id);


                    a1.text= ranking.time.ToString();
                    print("time: " + ranking.time);

                    a2.text = ranking.orbs.ToString();
                    print("orbs: " + ranking.orbs);

                    a3.text = ranking.stylish.ToString();
                    print("stylish: " + ranking.stylish);

                    a4.text = ranking.damage.ToString();
                    print("damage: " + ranking.damage);

                    a5.text = ranking.itemUsed.ToString();
                    print("itemUsed: " + ranking.itemUsed);

                    a6.text = ranking.rankBonus.ToString();
                    print("rankBonus: " + ranking.rankBonus);

                    break;
            }
        }
    }

    //SKIN
    IEnumerator GetRequestSkin(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    print("error");
                    break;
                case UnityWebRequest.Result.Success:

                    // print(webRequest.downloadHandler.text);
                    print("SKIN");
                    Skin skin = JsonUtility.FromJson<Skin>(webRequest.downloadHandler.text);

                    print("nombre skin: " + skin.name);
                    print("nombre skin: " + skin.code);
                    break;
            }
        }
    }
    //user
    IEnumerator GetRequestUser(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    print("error");
                    break;
                case UnityWebRequest.Result.Success:

                    // print(webRequest.downloadHandler.text);
                    print("User");
                    User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);

                    print("Name: " + user.firstName);
                    print("Lastname: " + user.lastName);
                    print("Birhday: " + user.dateOfBirthday);
                    print("middleName: " + user.middleName);
                    print("age: " + user.age);
                    print("email: " + user.email);
                    print("mnk: " + user.mnk);

                    break;
            }
        }
    }


}
