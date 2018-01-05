# ��2�� �z����g�������X�g

## 2.1 ArrayStack�F�z����g���������ȃX�^�b�N����

�ʏ�̔z��������������B���ۂ̏������s���ۂɂ͎���2�𖾊m�ɋ�ʂ���K�v������

- a.Length�F�z��(�z��Ƃ��Ċm�ۂ��Ă��郁�����̃T�C�Y)
- n�F�i�[���Ă���f�[�^�̃T�C�Y

�܂��A�g���Ǝ��k���s���ۂɂ͈��̃��[���̉��A�s���K�v������

�Ⴆ�΁A�z��T�C�Y��ύX����֐�(resize)���s���^�C�~���O�͈ȉ��̂悤�ɂ���

- �g��������ۂɂ̓������T�C�Y������Ȃ��Ȃ�����
- ���k������ۂɂ� $a.Length \geqq 3n$ �𖞂�����

�܂��Aresize�֐��� $a.Length = 2n$ �ɂ���֐��Ƃ���

| ArrayStack�̓��� |
|----|
| ![](�摜\ArrayStack.jpg) |

```cs
void resize<T>(ref T[] a, int n)
{
    T[] b = new T[n * 2];
    for (int i = 0; i < n; i++)
    {
        b[i] = a[i];
    }
    a = b;
}
```

���̊֐��͊��Ɋ֐��Ƃ��ėp�ӂ���Ă���

```cs
Array.Resize<T>(ref a, 2 * n);
```

## 2.2 FastArrayStack�F�œK�����ꂽArrayStack

ArrayStack�̏�����3��ނ����Ȃ�

- �g�p���郁�����̃��T�C�Y
- �f�[�^�̃V�t�g
	- Add�֐���Remove�֐�
- �f�[�^�̃R�s�[
	- �������̃��T�C�Y������Ƃ��Ɏ��{

�f�[�^�̃V�t�g��for�����g���čs�����Ƃ͔�����ł���A�����̊֐����g�����ق����ǂ�

```cs
void resize<T>(ref T[] a, int n)
{
    Array.Resize<T>(ref a, 2 * n);
}

void add<T>(ref T[] a, ref int n, int i, T x)
{
    if (n + 1 > a.Length)
        resize(ref a, n);

    Array.Copy(a, i, a, i + 1, n - i);

    a[i] = x;
    n++;
}

T remove<T>(ref T[] a, ref int n, int i)
{
    T x = a[i];
    if (n + 1 > a.Length)
        resize(ref a, n);

    Array.Copy(a, i + 1, a, i, n - i - 1);
    n--;

    if (a.Length >= 3 * n)
        resize<T>(ref a, n);

    return x;
}
```

�O�L�̎�@�Ɠ���͕ς��Ȃ����A�R�s�[�֐��͍œK������Ă��邽�߁A�S���Ɏ��s����邱�Ƃ������B

>�����I�ȍœK�������{����邱�Ƃ��l�����邽�߁A��������g�p���Ă������ق����ǂ�

## 2.3 ArrayQueue�F�z����g�����L���[
## 2.4 ArrayDeque�F�z����g���������ȑo�����L���[
## 2.5 DualArrayDeque�F2�̃X�^�b�N���������o�����L���[
## 2.6 RootishArrayStack�F��Ԍ����ɗD�ꂽ�z��X�^�b�N
## 2.7 �f�B�X�J�b�V�����Ɨ��K���

# ��3�� �A�����X�g

## 3.1 SLList�F�P�����A�����X�g
## 3.2 DLList: �o�����A�����X�g
## 3.3 SEList�F��Ԍ����̂悢�A�����X�g
## 3.4 �f�B�X�J�b�V�����Ɨ��K���

# ��4�� �X�L�b�v���X�g

## 4.1 ��{�I�ȍ\��
## 4.2 SkiplistSSet�F�����I��SSet
## 4.3 SkiplistList�F�����I�ȃ����_���A�N�Z�XList
## 4.4 �X�L�b�v���X�g�̉��
## 4.5 �f�B�X�J�b�V�����Ɨ��K���

# ��5�� �n�b�V���e�[�u��

## 5.1 ChainedHashTable: �`�F�C���@���g�����n�b�V���e�[�u��
## 5.2 LinearHashTable�F���`�T���@
## 5.3 �n�b�V���l
## 5.4 �f�B�X�J�b�V�����Ɨ��K���

# ��6�� �񕪖�

## 6.1 BinaryTree�F��{�I�ȓ񕪖�
## 6.2 BinarySearchTree�F�o�����X����Ă��Ȃ��񕪒T����
## 6.3 �f�B�X�J�b�V�����Ɨ��K���

# ��7�� �����_���񕪒T����

## 7.1 �����_���񕪒T����
## 7.2 Treap
## 7.3 �f�B�X�J�b�V�����Ɨ��K���

# ��8�� Scapegoat Tree

## 8.1 ScapegoatTree�F�����č\�z����񕪒T����
## 8.2 �f�B�X�J�b�V�����Ɨ��K���

# ��9�� �ԍ���

## 9.1 2-4 ��
## 9.2 RedBlackTree�F2-4 �؂̃V�~�����[�V����
## 9.3 �v��
## 9.4 �f�B�X�J�b�V�����Ɨ��K���

# ��10�� �q�[�v

## 10.1 BinaryHeap�F�Öق̓񕪖�
## 10.2 MeldableHeap�F�����_����Meldable �q�[�v
## 10.3 �f�B�X�J�b�V�����Ɨ��K���

# ��11�� ����A���S���Y��

## 11.1 ��r�Ɋ�Â�����
## 11.2 �v���\�[�g�Ɗ�\�[�g
## 11.3 �f�B�X�J�b�V�����Ɨ��K���

# ��12�� �O���t

## 12.1 AdjacencyMatrix�F�s��ɂ��O���t�̕\��
## 12.2 AdjacencyLists�F���X�g�̏W�܂�Ƃ��ẴO���t
## 12.3 �O���t�̑���
## 12.4 �f�B�X�J�b�V�����Ɨ��K���

# ��13�� �����������f�[�^�\��

## 13.1 BinaryTrie�F�f�W�^���T����
## 13.2 XFastTrie�FDoubly-Logarithmic ���ԂŌ������s��
## 13.3 YFastTrie�F���s���Ԃ�Doubly-Logarithmic ��SSet
## 13.4 �f�B�X�J�b�V�����Ɨ��K���

# ��14�� �O���������̒T��

## 14.1 Block Store
## 14.2 B ��
## 14.3 �f�B�X�J�b�V�����Ɨ��K���