# Beer Scoresheet Utility
This repository hosts the source and compiled versions for the Beer Scoresheet Utility.

### Purpose
The purpose of this utility is to provide an application to generate unique scoresheets for beer judging competitons (barcoded), and have a utility to read the barcodes from multiple scoresheets in a single file, and save them out as individually named files, after the competition has finished.


### Usage
The application is split into 2 tabs, the scoresheet generation and the scoresheet reading.


#### Scoresheet Generation
The generation tab requires you to provide a file name to save the new PDF scoresheets to.

There are currently 2 options for scoresheet styles, BJCP and AABC. These have slightly different layouts and slightly different scoring for the categories.

You can provide you own custom image to include in the scoresheets you generate. The BJCP style take a square logo, sized 104x104px @ 96DPI. The AABC style uses a rectangle logo, sized 491x67px @ 96DPI.

You can enter any number of scoresheets to generate (up to 99,999), **make sure you generate enough for your competition, the entire purpose of this utility is lost unless each and every scoresheet you use has a unique barcode**.

The name of your competition can also be provided here.

*If you wish you can load your own custom scoresheet file. It is recommended you take a copy of the existing file, hosted here, and modify it for your usage (so as to keep the parameters and data sets aligned).*

#### Scoresheet Reading
After the competition is complete you can process the scanned scoresheets into single files.

The input for this is a single PDF file, with each scoresheet on it's own page. **It is important to ensure the barcode is in the top right hand side of your scanned images, if the barcode is rotated in another direction, it may not be read correctly**

Scoresheets are saved as individual JPG files, in the folder specified.

You can prefix the saved files with some text, if you desire. There is also an option to include or exclude the leading zeros from the barcodes.

*When the scoresheets are processed, they wil be saved as per your options above. If for whatever reason, the barcode cannot be read, these scoresheets will be saved in an "error" subfolder for you to manually review*


## Download
Download the latest version here - [Version 0.1](https://github.com/m00nh34d/Beer-Scoresheet-Utility/releases/download/v0.1/setup.beer.scoresheet.utility.exe)

