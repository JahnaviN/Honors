img = imread('img.jpg');  %# Load a sample 3-D RGB image

%img(120:120:end,:,:) = 0;       
%img(:,120:120:end,:) = 0;

% size of option = 150 x 150
% a = img(100:220,200:320,:);

w = 100;

x = 550;
y = 100;
a = img(x:x+w,y:y+w,:);
imwrite(a,'p1.jpg');
img(x:x+w,y:y+w,:) = 255;

x = 40;
y = 250;
a = img(x:x+w,y:y+w,:);
imwrite(a,'p2.jpg');
img(x:x+w,y:y+w,:) = 255;

x = 500;
y = 800;
a = img(x:x+w,y:y+w,:);
imwrite(a,'p3.jpg');
img(x:x+w,y:y+w,:) = 255;

x = 100;
y = 1100;
a = img(x:x+w,y:y+w,:);
imwrite(a,'p4.jpg');
img(x:x+w,y:y+w,:) = 255;

x = 500
y = 600
a = img(x:x+w,y:y+w,:);
imwrite(a,'p5.jpg');
img(x:x+w,y:y+w,:) = 255;

imshow(img)
imwrite(img,'n.jpg');


