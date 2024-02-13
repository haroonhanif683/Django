from django.http import HttpResponse
from django.shortcuts import render

def Home(request):
    data = {
        'title':'Home Page',
        'bdata':'Welcome to Edu-tech',
        'clist':['PHP','Java','C','PYTHON'],
        'student_details':[
            {'name':'Ali','phone':92346797812},
            {'name':'Hussain','phone':92312457896}
            ]
    }
    return render(request,"index.html",data)

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
    
    