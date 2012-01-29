# AMEE in Excel
tightly integrates AMEE data into Microsoft Excel

## Getting started as a user

Requirements:
* Excel 2010
* Windows 7 (might work in Windows XP)

1.  Install the *AMEE in Excel* adding - http://code.labs.cityindex.com/AMEEInExcel/_setup/setup.exe
1.  Use the AMEE_* functions to pull data & calculations from AMEE

<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="https://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,115,0" width="640" height="390" id="7313b30ed11a47ffbe2fc3426a5114ab"><param name="movie" value="https://cityindex.viewscreencasts.com/public/ScreenrBusiness-3.5.1.swf"><param name="flashvars" value="v=3Fiie73014f2361a3^3^wd.rnEn.3be17bf4a1b*1a^0FF4*tnx3be17bf4a1b*D0CioServte13dafec254^t*r2xFF*cyd|13dafec254^f*0*nwce.es73014f2361aB^dk*FF^t"><param name="allowFullScreen" value="true"><param name="AllowScriptAccess" value="always"><embed id="e7313b30ed11a47ffbe2fc3426a5114ab" wmode="opaque" allowscriptaccess="always" src="https://cityindex.viewscreencasts.com/public/ScreenrBusiness-3.5.1.swf" flashvars="v=3Fiie73014f2361a3^3^wd.rnEn.3be17bf4a1b*1a^0FF4*tnx3be17bf4a1b*D0CioServte13dafec254^t*r2xFF*cyd|13dafec254^f*0*nwce.es73014f2361aB^dk*FF^t" allowfullscreen="true" width="640" height="390" pluginspage="http://www.macromedia.com/go/getflashplayer"></object>

## Getting started as a developer

Requirements:
* Excel 2010
* Windows 7
* Visual Studio 2010

1.  Clone this repo ```git clone --recursive https://github.com/mrdavidlaing/AMEEInExcel.git ```
1.  Open src/AMEEInExcel.sln in VS2010
1.  Run the command line build - ```msbuild src/build.xml```

## Related

1.  [AMEE.CS](https://github.com/cityindex/CIAPI.CS/blob/master/src/AMEE/AMEEClient.CS.Tests/DefraFixture.cs#L72) - .NET client library for AMEEConnect