% I = imread('p5.jpg');
% I2 = flip(I ,2);           %# horizontal flip
% I3 = flip(I ,1);           %# vertical flip
% I4 = flip(I3,2);           % both horizontal and vertical flip

% imwrite(I2,'h-flip.jpg');
% imwrite(I3,'v_flip.jpg');
% imwrite(I4,'hnv_flip.jpg');

I = imread('p1.jpg');
I2 = flip(I ,2);
imwrite(I2,'p1_h-flip.jpg');

I = imread('p2.jpg');
I2 = flip(I ,2);
imwrite(I2,'p2_h-flip.jpg');

I = imread('p3.jpg');
I2 = flip(I ,2);
imwrite(I2,'p3_h-flip.jpg');

I = imread('p4.jpg');
I2 = flip(I ,2);
imwrite(I2,'p4_h-flip.jpg');

I = imread('p5.jpg');
I2 = flip(I ,2);
imwrite(I2,'p5_h-flip.jpg');