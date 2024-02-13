from django.http import HttpResponse
from django.shortcuts import render

def Home(request):
    return render(request,"index.html")

def aboutus(request):
    return HttpResponse("Welcome to Eduloge")

def contact(request):
    return HttpResponse("Welcome to Eduloge")
def contactdetails(request,courseid):
    return HttpResponse(courseid)

def contactdetails1(request,courseid):
    return HttpResponse(courseid)


def contactdetails2(request,courseid):
    return HttpResponse(courseid)
    
    