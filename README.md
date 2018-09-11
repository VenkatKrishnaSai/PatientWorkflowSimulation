# PatientWorkflowSimulation
This Project Tells u about the patient workflow in hospital environment


This project illustrates the simulation of clinical workflow in a hospital environment.
The project mostly consists of three major modules, Patient Scheduler, Imaging System and Image Archive. 
We’re implementing these modules as: Radiology Information System (RIS), Modalities (Ultrasound, X-Ray and MRI), and Picture Archiving and Communication System (PACS) respectively.
When a patient walks into the hospital, s/he is registered.
The patient demography will be stored in a database, only accessible by RIS administrator. And is scheduled for appropriate imaging system by Patient Scheduler.

Then, Imaging System will fetch the list of patients, from RIS, scheduled for that particular day. 
Patient Scheduler, RIS, will send the necessary patient demography to the respective Imaging System along with modality details.

In this simulation, we’re considering implementation of Ultrasound, X-Ray and MRI as different Imaging System.

And finally, all the captured images and reports are archived to Image Archive, PACS.
The image archive also has capability to display all the patient records. Moreover, a patient may visit the same hospital once or more.

