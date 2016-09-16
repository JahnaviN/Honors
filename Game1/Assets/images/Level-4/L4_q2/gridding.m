img = imread('img.jpg');  %# Load a sample 3-D RGB image

%img(120:120:end,:,:) = 0;       
%img(:,120:120:end,:) = 0;

% size of option = 150 x 150
% a = img(100:220,200:320,:);
w = 110;

x = 700;
y = 1150;
a = img(x:x+w,y:y+w,:);
imwrite(a,'p1.jpg');
img(x:x+w,y:y+w,:) = 0;

x = 650;
y = 900;
a = img(x:x+w,y:y+w,:);
imwrite(a,'p2.jpg');
img(x:x+w,y:y+w,:) = 0;

x = 100;
y = 900;
a = img(x:x+w,y:y+w,:);
imwrite(a,'p3.jpg');
img(x:x+w,y:y+w,:) = 0;

x = 450;
y = 830;
a = img(x:x+w,y:y+w,:);
imwrite(a,'p4.jpg');
img(x:x+w,y:y+w,:) = 0;

x = 800;
y = 300;
a = img(x:x+w,y:y+w,:);
imwrite(a,'p5.jpg');
img(x:x+w,y:y+w,:) = 0;

imshow(img);

imwrite(img,'n.jpg');


