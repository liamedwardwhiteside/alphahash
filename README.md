# alphahash

## FAQ

### Is it collision-safe? Is it safe at all?

No, it is neither. I've easily generated collisions with the Bash script in the tools/ directory. And it was never intended to be secure or safe, so please don't think of it as such!

### Give me an output sample?!

```
Input  :  !"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~
Output : ORUXadgjLORUXadgjmORUXadgjmpRUXadgjmpsUXadmmmpsvXadgjmpsvyadgjmpsvyzCFILORUXadFILORUXadgILORUXa
```

(NOTE: the first character of the input is a space!)