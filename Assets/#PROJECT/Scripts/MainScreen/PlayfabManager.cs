using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _notification;
    [SerializeField] private TMP_InputField[] _userName;
    [SerializeField] private TMP_InputField[] _email;
    [SerializeField] private TMP_InputField[] _password;
    [SerializeField] private string _playfabId;
    public void SignIn()
    {
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest
        {
            Email = ActiveField(_email).text,
            Password = ActiveField(_password).text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true,
                ProfileConstraints = new PlayerProfileViewConstraints
                {
                    ShowContactEmailAddresses = true
                }
            }

        }, OnLoginSuccess, OnError);

    }
    public void Register()
    {
        if (ActiveField(_password).text.Length < 6 || ActiveField(_email).text.Length == 0 || ActiveField(_userName).text.Length < 4)
        {
            _notification.text = "Password/Email/UserName is too short!";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Username = ActiveField(_userName).text,
            Email = ActiveField(_email).text,
            Password = ActiveField(_password).text,
            RequireBothUsernameAndEmail = true
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    public void PasswordReset()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = ActiveField(_email).text,
            TitleId = "3028F"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }
    private void OnPasswordReset(SendAccountRecoveryEmailResult obj)
    {
        _notification.text = "Password Reset Mail Sent!";
    }
    private void OnRegisterSuccess(RegisterPlayFabUserResult obj)
    {

        _notification.text = "Registered and Logged In!";
        var request = new AddOrUpdateContactEmailRequest
        {
            EmailAddress = ActiveField(_email).text,
        };
        PlayFabClientAPI.AddOrUpdateContactEmail(request, result =>
        {
            Debug.Log("The player's account has been updated with a contact email");
        }, OnError);
    }
    private void OnLoginSuccess(LoginResult result)
    {
        if(result.InfoResultPayload.PlayerProfile.ContactEmailAddresses.Count > 0)
        {
            //Log the player in
            Debug.Log("SUCCESSFULLY LOGGED IN");
        }
        else
        {
            Debug.Log("NO EMAIL");
        }
    }
    private void OnError(PlayFabError error)
    {
        _notification.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
    private TMP_InputField ActiveField(TMP_InputField[] field)
    {
        TMP_InputField result = null;
        foreach (var f in field)
        {
            if (f != null) result = f;
        }
        return result;
    }
}
