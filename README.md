# BarberSystem
# Barber System

نظام إدارة صالون حلاقة (Barber System) — مشروع تعليمي/شخصي يهدف لتنظيم عملية التوظيف، الحجز، تنفيذ الخدمة، وتقييمها.

## نظرة عامة
نظام قاعدة بيانات ومنظومة Backend صغيرة تقدر تربطها مع واجهة ويب أو موبايل. الـ schema يغطّي:
- **توظيف الحلاقين (Barber Application)**: إدارة طلبات التقديم والموافقة.
- **الحلاقين (Barbers)**: بيانات الحلاق وخدماته.
- **الزبائن (Customers)**: بيانات العملاء.
- **الخدمات (Services)**: أنواع الخدمات، مدة كل خدمة، والسعر (اختياري).
- **المواعيد (Appointments)**: حجز الخدمة بين الزبون والحلاق مع حالة دورة التطبيق.
- **التقييمات (Ratings)**: تقييم الزبائن للخدمة بعد اكتمال الموعد.

> ملاحظة: هذا المشروع يتجنب ذكر نظام المدفوعات (Payments) كما طلب المستخدم.

## الغرض من الـ Schema
تنظيم البيانات بحيث تضمن تدفق منطقي من:
1. تقديم الحلاق → مراجعة/قبول  
2. حجز موعد → تنفيذ الخدمة  
3. تقييم الخدمة  
الهدف: تسهيل إدارة المواعيد، متابعة حالة الطلبات، وتحسين تجربة الحلاق والعميل.

## بنية مختصرة للجداول (نماذج حقول)
- **Barbers**
  - BarberId (PK)
  - FullName
  - Phone
  - Bio
  - IsActive
  - CreatedAt

- **BarberApplications**
  - ApplicationId (PK)
  - BarberId (FK, optional if linked after القبول)
  - FullName
  - ContactInfo
  - ExperienceYears
  - ServicesOffered (مثلاً: JSON أو رابطه إلى جدول Services)
  - Status (Pending, Reviewed, Accepted, Rejected)
  - SubmittedAt
  - ReviewedAt

- **Customers**
  - CustomerId (PK)
  - FullName
  - Phone
  - Email
  - CreatedAt

- **Services**
  - ServiceId (PK)
  - Title
  - DurationMinutes
  - Price (اختياري)
  - Description

- **Appointments**
  - AppointmentId (PK)
  - CustomerId (FK)
  - BarberId (FK)
  - ServiceId (FK)
  - StartAt (DateTime)
  - DurationMinutes
  - Status (Scheduled, InProgress, Completed, Cancelled)
  - Notes

- **Ratings**
  - RatingId (PK)
  - AppointmentId (FK)
  - CustomerId (FK)
  - BarberId (FK)
  - Score (1-5)
  - Comment
  - CreatedAt

## مثال على دورة التطبيق (Application Cycle)
1. الزبون/الحلاق يقدّم الطلب (BarberApplication)  
2. المسؤول يراجع الطلب ويغيّر الحالة إلى Accepted/Rejected  
3. إذا قُبل، يتحوّل المتقدم إلى سجل Barber ويمكنه استقبال مواعيد  
4. الحجز → التنفيذ → بعد الاكمال، الزبون يترك تقييم (Ratings)

## كيف تشغّله (مختصر)
1. انسخ المستودع:
   ```bash
   git clone <repo-url>
