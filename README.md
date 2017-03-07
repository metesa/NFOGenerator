# NFOGenerator
[![](https://img.shields.io/badge/TAiCHi-encoding-brightgreen.svg?style=flat)](https://github.com/metesa/NFOGenerator)
[![GitHub version](https://badge.fury.io/gh/metesa%2FNFOGenerator.svg)](https://badge.fury.io/gh/metesa%2FNFOGenerator)

Buiding Status：   master [![Build Status](https://travis-ci.org/metesa/NFOGenerator.svg?branch=master)](https://travis-ci.org/metesa/NFOGenerator)
dev [![Build Status](https://travis-ci.org/metesa/NFOGenerator.svg?branch=dev)](https://travis-ci.org/metesa/NFOGenerator)

---
An internal tool which can generate NFO with specific form automatically.

## License

### 1. NFOGenerator

>  Copyright © 2017 Troy Lewis and Jevenski C. Woodsmann. All Rights Reserved
>
>  Licensed under the Apache License, Version 2.0 (the "License");
>  you may not use this file except in compliance with the License.
>  You may obtain a copy of the License at
>
>      http://www.apache.org/licenses/LICENSE-2.0
>
>  Unless required by applicable law or agreed to in writing, software
>  distributed under the License is distributed on an "AS IS" BASIS,
>  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
>  See the License for the specific language governing permissions and
>  limitations under the License.

### 2. MediaInfo
> Redistributions in binary form must reproduce the following sentence (including the link to the website) in the documentation and/or other materials provided with the distribution.
> 
> This product uses [MediaInfo](http://mediaarea.net/MediaInfo) library, Copyright (c) 2002-2016 [MediaArea.net SARL](mailto:Info@MediaArea.net).

## Requirement

* DotNet Framework 3.5

<https://www.microsoft.com/zh-CN/download/details.aspx?id=21>

## Introduction

<https://github.com/metesa/NFOGenerator>

## Instruction

1. **First, you should have a media file. It is better if it has a standard release name.**
![step1](./Screenshots/Step_1.png)

2. **Drag and drop it on the Input box or you can click the "Browse" button on the Input area to load the media file. When you have set input file, the program will automatically read some necessary media info and then display on the screens.**
![step2](./Screenshots/Step_2.png)

3. **If there is something missing or "unknown", the label will turn red so you can easily notice them. Now edit them to get black again.**

4. **For the missing iMDB info, click "Search by Title" button if you already have the correct title and correct year, and the program will open a new dialog showing search result. Then you can choose the one you want.**
![step3](./Screenshots/Step_3.png)

5. **For the missing source name info, just enter it in the textbox.**
![step4](./Screenshots/Step_4.png)
![step5](./Screenshots/Step_5.png)

6. **For the unknown audio language info, click the audio item to load the info.**
![step6](./Screenshots/Step_6.png)
**Edit the "Unknown" item and click "Edit Audio" button, and it will turn black again.**
![step7](./Screenshots/Step_7.png)
![step8](./Screenshots/Step_8.png)

7. **After all missing info fixed, change the target location if needed.**
![step9](./Screenshots/Step_9.png)

8. **After everything done, click "GO!" button on bottom right.**
![step10](./Screenshots/Step_10.png)

9. **Bang! The NFO file with specific form will be generated.**
![step11](./Screenshots/Step_11.png)


## Miscellaneous

* About standard release name

> For movie, it's like
> 
>     [Movie name] [Year] [Resolution] [Source] [Audio] [Video]-[Release Group]
>     e.g. Big Buck Bunny 2008 1080p DM DD5.1 x264-Group
>     
> For TV episode, it's like
> 
>     [TV name] [SxxExx] [Resolution] [Source] [Audio] [Video]-[Release Group]
>     e.g. Breaking Bad S01E01 1080p BluRay DD5.1 x264-Group
>     
> For TV season pack, it's like
> 
>     [TV name] [Sxx] [Resolution] [Source] [Audio] [Video]-[Release Group]
>     e.g. Breaking Bad S01 1080p BluRay DD5.1 x264-Group
