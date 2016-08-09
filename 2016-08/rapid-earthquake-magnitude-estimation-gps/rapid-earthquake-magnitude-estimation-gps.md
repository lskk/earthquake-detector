
# Catatan Kuliah Umum Rapid Earthquake Magnitude Estimation Using Near Realtime GPS Data

oleh Hendy Irawan (http://orcid.org/0000-0002-5231-2802) - 9 Agustus 2016

Source: https://github.com/lskk/emergency-work

Published at: https://figshare.com/account/projects/15261/articles/3549624

Kuliah Umum Rapid Earthquake Magnitude Estimation Using Near Realtime GPS Data Prof. Yusaku Ohta Associate Professor Crustal Physics Laboratory, Research Center for Prediction of Earthquakes and Volcanic Eruptions Tohoku University

Acara bertempat di Auditorium BMKG, pada tanggal 9 Agustus 2016, berlangsung dari jam 09:00 WIB sampai dengan jam 13:00 WIB. 

Live at:
http://media.bmkg.go.id/Live.bmkg?ID=2625949045519124
 
http://www.bmkg.go.id

Via Dr. Rahma Hanifa, Dr. Abdul Muhari, Himpunan Mahasiswa Oseanografi ITB, Carmadi Machbub, Ary Setijadi Prihatmanto, Egi Hidayat, Astri Novianty, Irwan Meilano, Irina Rafliana

![Kuliah Umum Rapid Earthquake Magnitude Estimation Using Near Realtime GPS Data](Kuliah-Umum-Yusaku-Ohta-9Ags2016.jpg)

## Introduction

![Room](room.jpg)

![quasi-real-time-fault-estimation.jpg](quasi-real-time-fault-estimation.jpg)

## Relevansi dengan LSKK

<del>Hipotesis sementara yang relevan dengan LSKK, adalah bila Semut/ACT banyak penggunanya (terutama terkumpul di satu area), maka data GPS mereka (yang realtime) berpotensi untuk dimasukkan ke algoritma RAPiD ini untuk menghitung magnitude gempa tanpa seismograf, bahkan lebih akurat dari seismograf</del>

<del>Namun saya belum jelas saat konfirmasi apakah hal tersebut mungkin dilakukan (deteksi murni berbasis smartphone, tanpa geostation, tanpa seismograf). :(</del>

Saya telah dijelaskan oleh Pak Endra (GREAT ITB) bahwa GPS yang digunakan harus geodetik, jadi akurasinya 1-10mm .. tidak bisa pakai GPS smartphone. :( Nah, dengan GPS module tersebut, algoritma RAPiD ini untuk menghitung magnitude gempa dengan lebih cepat tanpa seismograf, bahkan lebih akurat dari seismograf.

Tambahan Bu Rahma: Sistemnya tadi dibuat independent, jadi semuadari GNSS aja, ngga pake data seismik.

Dari Pak Ary: Kita punya GPS module yang bisa RTK. Memang gak gampang dapetnya dan sedikit mahal (USD 500) jadi bisa saja diteliti menggunakan GPS modul ini.

## Automatic detection of aftershocks

![Automatic detection of aftershocks](automatic-detection-of-aftershocks.jpg)

## GSI GEONET real-time analysis system

![gsi-geonet-real-time-analysis-system.jpg](gsi-geonet-real-time-analysis-system.jpg)

## Single rectangular fault model

![Single rectangular fault model](Single rectangular fault model.jpg)

## Slip distribution model

![Slip distribution model](Slip distribution model.jpg)

## Data set for the tests

![Data set for the tests](Data set for the tests.jpg)

## Result 2003 Tokachi-oki Earthquake (Mw 8.0)

![Result 2003 Tokachi-oki Earthquake (Mw 8.0)](Result 2003 Tokachi-oki Earthquake.jpg)

## Result: Nankai Earthquake (Simulation: Mw 8.2)

![Result: Nankai Earthquake](Result Nankai Earthquake.jpg)

## Actual working example of REGARD

![Actual working example of REGARD](Actual working example of REGARD.jpg)

Algoritma REGARD dapat memperkirakan single finite fault model dalam waktu 6 menit.

**Tambahan Bu Rahma:** 6 menit waktu kasus real Gempa Kumamoto 2012 (gempa di darat dg magnitude 7.0).

Waktu quasi real time simulation dg data gempa Tohoku magnitude 9.0 diperlukan waktu 2 menit sampai hasil stabil.

Knp kumamoto lbh lama rupanya krn sedimentasi di sana, yg menyebabkan propagasi lebih lama

## Application of tFISH to real data

![Application of tFISH to real data](Application of tFISH to real data.jpg)

## Effectiveness of combination use of GNSS and offshore tsunami data tFISH-RAPID

![Effectiveness of combination use of GNSS and offshore tsunami data tFISH-RAPID](Effectiveness of combination use of GNSS and offshore tsunami data tFISH-RAPID.jpg)

## Effective combination of various methods

![Effective combination of various methods](Effective combination of various methods.jpg)

Agar lebih efektif dan akurat, 4 teknik perlu dikombinasikan:
1. Short-period seismic wave
2. GNSS
3. OBPG; GPS buoy
4. Offshore wave gauge; Tide gauge

## Conclusions

![Conclusion](conclusion.jpg)

## Hendy's Questions

Konichiwa, Yusaku Ohta sensei.
Hendy to moshimas.
Bandung kooka daigaku kara mairimashita.
Senko wa Denki kougakudes.

1. What is the difference between tFISH, RAPID, and REGARD?
2. What are the sensors support by this technique? Is it possible to use regular GPS/accelerometer/gyro sensors in multiple smartphones? If so, how many sensors/users are needed to have accurate estimation.

Douzo yoroshiku onegaishimas.
Arigatou gozaimasu.

**Answer:**

1. tFISH -> only waterfloor -- not coseismic model
   RAPID is from seismic wave -- can generate coseismic model

2. Using GNSS, GLONASS, etc. in geostation


## Photos

### Sambutan dari Pak Riyadi

![Sambutan Pak Riyadi.jpg](Sambutan Pak Riyadi.jpg)

### Foto bersama

![foto bersama.jpg](foto bersama.jpg)

### Dimoderatori Pak Taufik

![Dimoderatori Pak Taufik.jpg](Dimoderatori Pak Taufik.jpg)

### Lecture Prof Ohta

![Lecture Prof Ohta.jpg](Lecture Prof Ohta.jpg)

### Sambutan dan pembukaan Kepala BMKG

![Sambutan dan pembukaan Kepala BMKG.jpg](Sambutan dan pembukaan Kepala BMKG.jpg)

### Penyerahan cinderamata

![Penyerahan cinderamata.jpg](Penyerahan cinderamata.jpg)

### Peserta kuliah umum

![Peserta kuliah umum.jpg](Peserta kuliah umum.jpg)

