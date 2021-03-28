from django.shortcuts import render, HttpResponse
from django.template.context_processors import csrf
from django.http import HttpResponse, HttpResponseRedirect
from web_scapper.utils import get_MongoClient, send_pn
from django.views.decorators.http import require_POST
import os
import pymongo
from datetime import datetime
import requests
from bs4 import BeautifulSoup
from django.core.paginator import Paginator, EmptyPage, PageNotAnInteger
from bson import ObjectId
import time
import threading

login_error = "Invalid Credentials!"

# Create your views here.

def get_weather():
    page1 = requests.get('https://www.google.com/search?lr=lang_en&ie=UTF-8&q=weather')
    soup1 = BeautifulSoup(page1.content, 'lxml')
    h = soup1.find("span", class_='BNeawe tAd8D AP7Wnd')
    # h = soup1.find("div", id_='wob_loc')
    city = str(h.text).split(",")[0]

    response = requests.get('http://api.openweathermap.org/data/2.5/weather?q='+city+'&APPID=46c58e3eded12aaeb86c8287b19e4de5')
    weather_report = {}
    if response.status_code == 200:
        data = response.json()
        main = data['main']
        weather_report['city'] = city
        weather_report['temp'] = int(main['feels_like'] - 273.15)
        weather_report['humidity'] = main['humidity']
        weather_report['weather'] = data['weather'][0]['description']
        weather_report['icon'] = data['weather'][0]['icon']
    
    return weather_report

def index(request):
    os.system('python latest_news/fetch_news.py')

    myclient = pymongo.MongoClient("mongodb://localhost:27017/")
    mydb = myclient["web_scraper"]
    mycol = mydb["news_table"]

    news = mycol.find()
    news_list = []
    for i in news:
        time = i['DateTime']
        current_time = datetime.now()
        duration = (current_time - time).total_seconds()
        i['DateTime'] = int(duration//60)
        i['id'] = i['_id']
        news_list.append(i)

        # Delete news with duration more than 36 hrs(129600 seconds) 
        if duration>129600:              
            mycol.delete_one({'Headline' : i['Headline']})
    
    last_five = []
    for i in range(5):
        last_five.append(news_list.pop())
    
    last_eight = []
    for i in range(8):
        last_eight.append(news_list.pop())

    weather_report = get_weather()
            
    return render(request, 'index.html', {'news_list' : news_list , 'last_five' : last_five, 'last_eight' : last_eight, 'weather_report' : weather_report})

def business(request):
    # os.system('python3 latest_news/fetch_news.py')

    myclient = pymongo.MongoClient("mongodb://localhost:27017/")
    mydb = myclient["web_scraper"]
    mycol = mydb["news_table"]

    news = mycol.find({'Category' : 'Business'})
    news_list = []
    for i in news:
        time = i['DateTime']
        current_time = datetime.now()
        duration = (current_time - time).total_seconds()
        i['DateTime'] = int(duration//60)
        news_list.append(i)

        # Delete news with duration more than 36 hrs(129600 seconds) 
        if duration>129600:              
            mycol.delete_one({'Headline' : i['Headline']})
    
    last_three = []
    for i in range(3):
        last_three.append(news_list.pop())

    last_six = []
    if len(news_list)>6:
        for i in range(6):
            last_six.append(news_list.pop())
    else:
        for i in range(len(news_list)):
            last_six.append(news_list.pop())
    
    weather_report = get_weather()

    return render(request, 'business.html',{'news_list' : news_list , 'last_three' : last_three, 'last_six': last_six, 'weather_report' : weather_report})

def tech(request):
    # os.system('python3 latest_news/fetch_news.py')

    myclient = pymongo.MongoClient("mongodb://localhost:27017/")
    mydb = myclient["web_scraper"]
    mycol = mydb["news_table"]

    news = mycol.find({'Category' : 'Tech'})
    news_list = []
    for i in news:
        time = i['DateTime']
        current_time = datetime.now()
        duration = (current_time - time).total_seconds()
        i['DateTime'] = int(duration//60)
        news_list.append(i)

        # Delete news with duration more than 36 hrs(129600 seconds) 
        if duration>129600:              
            mycol.delete_one({'Headline' : i['Headline']})
    
    last_three = []
    for i in range(3):
        last_three.append(news_list.pop())

    last_six = []
    if len(news_list)>6:
        for i in range(6):
            last_six.append(news_list.pop())
    else:
        for i in range(len(news_list)):
            last_six.append(news_list.pop())
        
    weather_report = get_weather()

    return render(request, 'tech.html', {'news_list' : news_list , 'last_three' : last_three, 'last_six': last_six, 'weather_report' : weather_report}) 

def sports(request):
    # os.system('python3 latest_news/fetch_news.py')

    myclient = pymongo.MongoClient("mongodb://localhost:27017/")
    mydb = myclient["web_scraper"]
    mycol = mydb["news_table"]

    news = mycol.find({'Category' : 'Sports'})
    news_list = []
    for i in news:
        time = i['DateTime']
        current_time = datetime.now()
        duration = (current_time - time).total_seconds()
        i['DateTime'] = int(duration//60)
        news_list.append(i)

        # Delete news with duration more than 36 hrs(129600 seconds) 
        if duration>129600:              
            mycol.delete_one({'Headline' : i['Headline']})
    
    last_three = []
    for i in range(3):
        last_three.append(news_list.pop())

    last_six = []
    if len(news_list)>6:
        for i in range(6):
            last_six.append(news_list.pop())
    else:
        for i in range(len(news_list)):
            last_six.append(news_list.pop())
    
    weather_report = get_weather()

    return render(request, 'sports.html', {'news_list' : news_list , 'last_three' : last_three, 'last_six': last_six, 'weather_report' : weather_report}) 

def entertainment(request):
    # os.system('python3 latest_news/fetch_news.py')

    myclient = pymongo.MongoClient("mongodb://localhost:27017/")
    mydb = myclient["web_scraper"]
    mycol = mydb["news_table"]

    news = mycol.find({'Category' : 'Entertainment'})
    news_list = []
    for i in news:
        time = i['DateTime']
        current_time = datetime.now()
        duration = (current_time - time).total_seconds()
        i['DateTime'] = int(duration//60)
        news_list.append(i)

        # Delete news with duration more than 36 hrs(129600 seconds) 
        if duration>129600:              
            mycol.delete_one({'Headline' : i['Headline']})
    
    last_three = []
    for i in range(3):
        last_three.append(news_list.pop())

    last_six = []
    if len(news_list)>6:
        for i in range(6):
            last_six.append(news_list.pop())
    else:
        for i in range(len(news_list)):
            last_six.append(news_list.pop())
    
    weather_report = get_weather()

    return render(request, 'entertainment.html', {'news_list' : news_list , 'last_three' : last_three, 'last_six': last_six, 'weather_report' : weather_report}) 

def politics(request):
    # os.system('python3 latest_news/fetch_news.py')

    myclient = pymongo.MongoClient("mongodb://localhost:27017/")
    mydb = myclient["web_scraper"]
    mycol = mydb["news_table"]

    news = mycol.find({'Category' : 'Politics'})
    news_list = []
    for i in news:
        time = i['DateTime']
        current_time = datetime.now()
        duration = (current_time - time).total_seconds()
        i['DateTime'] = int(duration//60)
        news_list.append(i)

        # Delete news with duration more than 36 hrs(129600 seconds) 
        if duration>129600:              
            mycol.delete_one({'Headline' : i['Headline']})
    
    last_three = []
    for i in range(3):
        last_three.append(news_list.pop())

    last_six = []
    if len(news_list)>6:
        for i in range(6):
            last_six.append(news_list.pop())
    else:
        for i in range(len(news_list)):
            last_six.append(news_list.pop())
    
    weather_report = get_weather()

    return render(request, 'politics.html', {'news_list' : news_list , 'last_three' : last_three, 'last_six': last_six, 'weather_report' : weather_report})

def adminlogin(request):
    if not request.session.get('useremail', None):
        print("user is not logged in")
        c = {}
        c.update(csrf(request))
        return render(request, 'adminlogin.html', c)
    else:
        return HttpResponseRedirect('/adminhome')
    
@require_POST
def login(request):
    useremail = request.POST.get('useremail')
    password = request.POST.get('password')
    myclient, mydb = get_MongoClient()
    mycol = mydb["admin"]
    userobj = mycol.find_one({"useremail":useremail})
    # print(userobj]["password"])
    if userobj is None:
        return render(request, 'adminlogin.html', {'error':login_error})
    else:
        # print(userobj["password"])
        if password == userobj["password"]:
            request.session["useremail"] = useremail
            return HttpResponseRedirect('/adminhome')
        else:
            return render(request, 'adminlogin.html', {'error':login_error})
    return render(request, 'adminlogin.html')

def logout(request):
    del request.session['useremail']
    return HttpResponseRedirect('/adminlogin')

# All news page for Admin
def adminhome(request):
    if not request.session.get('useremail', None):
        print("user is not logged in")
        c = {}
        c.update(csrf(request))
        return render(request, 'adminlogin.html', c)

    c = {}
    c.update(csrf(request))
    #Getting news list from database
    myclient, mydb = get_MongoClient()
    mycol = mydb["news_table"]

    news = mycol.find()
    news_list = []
    for i in news:
        time = i['DateTime']
        current_time = datetime.now()
        #Setting the duration
        duration = (current_time - time).total_seconds()
        i['DateTime'] = int(duration//60)
        i['id'] = i['_id']
        news_list.append(i)
    
    page = request.GET.get('page', 1)

    #Django Pagination
    paginator = Paginator(news_list, 10)

    try:
        news = paginator.page(page)
    
    #For first page
    except PageNotAnInteger:
        news = paginator.page(1)

    #For last page
    except EmptyPage:
        news = paginator.page(paginator.num_pages)

    return render(request, 'adminhome.html', {"news" : news})

# Reported News page for admin
def reported(request):
    if not request.session.get('useremail', None):
        print("user is not logged in")
        c = {}
        c.update(csrf(request))
        return render(request, 'adminlogin.html', c)

    #Getting news list from database
    c = {}
    c.update(csrf(request))
    myclient, mydb = get_MongoClient()
    mycol = mydb["news_table"]

    news = mycol.find({'Reported' : True})
    news_list = []

    for i in news:
        time = i['DateTime']
        current_time = datetime.now()
        #Setting the duration
        duration = (current_time - time).total_seconds()
        i['DateTime'] = int(duration//60)
        i['id'] = i['_id']
        news_list.append(i)

    nl_len = len(news_list)

    page = request.GET.get('page', 1)

    #Django Pagination
    paginator = Paginator(news_list, 10)

    try:
        news = paginator.page(page)
    
    #For first page
    except PageNotAnInteger:
        news = paginator.page(1)

    #For last page
    except EmptyPage:
        news = paginator.page(paginator.num_pages)
    return render(request, 'reported.html', {"news" : news, "nl_len" : nl_len})

# Showing news of past x hrs
def oldnews(request, hrs):

    #Getting news list from database
    c = {}
    c.update(csrf(request))
    myclient, mydb = get_MongoClient()
    mycol = mydb["news_table"]

    news = mycol.find()
    news_list = []

    for i in news:
        time = i['DateTime']
        current_time = datetime.now()
        #Setting the duration
        duration = (current_time - time).total_seconds()
        i['DateTime'] = int(duration//60)
        i['id'] = i['_id']

        # Keeping news which were latest by 6 hrs (21600 sec)
        if(duration < (hrs * 3600)):
            news_list.append(i)

    nl_len = len(news_list)

    page = request.GET.get('page', 1)

    #Django Pagination
    paginator = Paginator(news_list, 10)

    try:
        news = paginator.page(page)
    
    #For first page
    except PageNotAnInteger:
        news = paginator.page(1)

    #For last page
    except EmptyPage:
        news = paginator.page(paginator.num_pages)
    weather_report = get_weather()
    return render(request, 'shownews.html', {"news" : news, "nl_len" : nl_len, 'weather_report' : weather_report})

@require_POST
def delete_news(request):
    if not request.session.get('useremail', None):
        print("user is not logged in")
        c = {}
        c.update(csrf(request))
        return render(request, 'adminlogin.html', c)

    #Deleting news from database
    myclient, mydb = get_MongoClient()
    mycol = mydb["news_table"]
    id = request.POST.get('newsid')
    mycol.delete_one({'_id' : ObjectId(id)})
    print("\n-------News Id : ",id, "deleted successfully!--------\n")

    return HttpResponseRedirect('/adminhome')

@require_POST
def report(request):
    # Updating 'reported' field of news in database
    myclient, mydb = get_MongoClient()
    mycol = mydb["news_table"]
    id = request.POST.get('newsid')
    myquery = { "_id": ObjectId(id)}
    newvalues = { "$set": { "Reported": True } }
    mycol.update_one(myquery, newvalues)
    print("\n-------News Id : ",id, "reported successfully!--------\n")

    return HttpResponseRedirect("/home")

# Searching News
@require_POST
def search(request):

    # Getting Search query
    query = request.POST.get('squery')
    # For null query
    if query is None:
        return HttpResponseRedirect("/home")

    myclient, mydb = get_MongoClient()
    mycol = mydb["news_table"]

    # Using MongoDB's Text index for searching on Headline, Content, Category and Source fields
    news = mycol.find({"$text" : {"$search" : query}})
    news_list = []

    for i in news:
        news_list.append(i)
    nl_len = len(news_list)
    weather_report = get_weather()
    return render(request, 'search.html', {"news" : news_list, "nl_len" : nl_len, 'weather_report' : weather_report})
    
def push_noti(request):
    webpush = {"group": "all"}
    return render(request, 'notification.html', {"webpush" : webpush})

def demo_notif(request):
    return render(request,'demoNotif.html')

@require_POST
def send_notif(request):
    head = request.POST.get('head')
    body = request.POST.get('body')
    send_pn(head, body)
    return HttpResponseRedirect('/demo_notif')