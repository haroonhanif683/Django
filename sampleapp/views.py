from django.shortcuts import render

def home(request):
    return render(request,"index.html")

def contact(request):
    return render(request,"contact.html")

def about(request):
    return render(request,"about.html")

def location(request):
    return render(request,"locations.html")

def register(request):
    return render(request,"register.html")