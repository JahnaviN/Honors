img = imread('img.jpg');  %# Load a sample 3-D RGB image


w = 120;

% x = 850;
% y = 150;
% a = img(x:x+w,y:y+w,:);
% imwrite(a,'p1.jpg');
% img(x:x+w,y:y+w,:) = 255;
% 
% x = 300;
% y = 100;
% a = img(x:x+w,y:y+w,:);
% imwrite(a,'p2.jpg');
% img(x:x+w,y:y+w,:) = 255;
% 
% x = 40;
% y = 1500;
% a = img(x:x+w,y:y+w,:);
% imwrite(a,'p3.jpg');
% img(x:x+w,y:y+w,:) = 255;
% 
% x = 700;
% y = 900;
% a = img(x:x+w,y:y+w,:);
% imwrite(a,'p4.jpg');
% img(x:x+w,y:y+w,:) = 255;
% 
% x = 400;
% y = 1550;
% a = img(x:x+w,y:y+w,:);
% imwrite(a,'p5.jpg');
% img(x:x+w,y:y+w,:) = 255;

%---------------------------------%
x = 700;
y = 1200;
a = img(x:x+w,y:y+w,:);
imwrite(a,'ot3.jpg');
img(x:x+w,y:y+w,:) = 255;
%---------------------------------%

imshow(img)
% imwrite(img,'n.jpg');


